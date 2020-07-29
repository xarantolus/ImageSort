using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSort
{
    public partial class SortForm : Form
    {
        public static List<string> files = null;
        public static string locationDirectory = "";
        public static string destinationDirectory = "";
        public static int currentIndex = 0;

        public SortForm()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            return false;
        }

        async void moveCurrent(string from, string to)
        {
            do
            {
                string m = "";
                var i = (Image)viewBox.Image.Clone();
                var moveTask = Task<bool>.Run(() =>
                {
                    try
                    {
                        lock (i)
                        {
                            var newPath = System.IO.Path.Combine(destinationDirectory, files[currentIndex].Split('\\').Last());

                            i.Save(newPath);

                            var oldFI = new FileInfo(files[currentIndex]);

                            var newFI = new FileInfo(newPath);

                            // Copy file attributes
                            newFI.CreationTime = oldFI.CreationTime;
                            newFI.LastWriteTime = oldFI.LastWriteTime;
                            newFI.LastAccessTime = oldFI.LastAccessTime;
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        m = ex.Message;
                        return false;
                    }
                });
                await moveTask;
                if (!moveTask.Result)
                {
                    if (m != "")
                    {
                        if (MessageBox.Show(m, Properties.Strings.Error, MessageBoxButtons.RetryCancel) != DialogResult.Retry)
                        {
                            break;
                        }
                        m = "";
                    }
                }
                else
                {
                    break;
                }
            } while (true);
        }
        void NextImage()
        {
            if (currentIndex != files.Count - 1)
            {
                currentIndex++;
            }
            LoadCurrent();
        }
        void PreviousImage()
        {
            if (currentIndex != 0)
            {
                currentIndex--;
            }
            LoadCurrent();
        }
        void LoadCurrent()
        {
            lock (files)
            {
                var filename = files[currentIndex];

                this.Text = filename.Split('\\').Last() + " - " + (currentIndex + 1) + "/" + files.Count + " - ImageSort";
                resolutionLabel.Text = Properties.Strings.Loading;


                viewBox.LoadCompleted += new AsyncCompletedEventHandler(delegate (object sender, AsyncCompletedEventArgs target)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        lock (viewBox.Image)
                        {
                            var rotated = true;
                            // If there's some flip/rotation metadata
                            // from https://stackoverflow.com/a/23400751
                            if (Array.IndexOf(viewBox.Image.PropertyIdList, 274) > -1)
                            {
                                Image img = (Image)viewBox.Image.Clone();
                                var orientation = (int)img.GetPropertyItem(274).Value[0];
                                switch (orientation)
                                {
                                    case 1:
                                        rotated = false;
                                        // No rotation required.
                                        break;
                                    case 2:
                                        img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                        break;
                                    case 3:
                                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                        break;
                                    case 4:
                                        img.RotateFlip(RotateFlipType.Rotate180FlipX);
                                        break;
                                    case 5:
                                        img.RotateFlip(RotateFlipType.Rotate90FlipX);
                                        break;
                                    case 6:
                                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                        break;
                                    case 7:
                                        img.RotateFlip(RotateFlipType.Rotate270FlipX);
                                        break;
                                    case 8:
                                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                        break;
                                }
                                // This EXIF data is now invalid and should be removed.
                                img.RemovePropertyItem(274);

                                viewBox.Image = img;
                            }
                            else
                            {
                                rotated = false;
                            }

                            var size = viewBox.Image.Size;
                            resolutionLabel.Text = size.Width + " x " + size.Height + "px" + (rotated ? " (r)" : "");
                        }
                    });
                });

                viewBox.LoadAsync(filename);

                if (currentIndex == 0)
                {
                    backButton.Enabled = false;
                }
                else
                {
                    backButton.Enabled = true;
                }

                if (currentIndex == files.Count - 1)
                {
                    nextButton.Enabled = false;
                }
                else
                {
                    nextButton.Enabled = true;
                }
            }
        }

        private void SortForm_Shown(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                Description = Properties.Strings.FolderBrowserSourceDesc,
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };
            while (fd.ShowDialog() != DialogResult.OK) { System.Threading.Thread.Sleep(500); }
            Console.WriteLine(fd.SelectedPath);
            locationDirectory = fd.SelectedPath;

            fd.Reset();

            fd.ShowNewFolderButton = true;
            fd.Description = Properties.Strings.FolderBrowserTargetDesc;
            while (fd.ShowDialog() != DialogResult.OK) { System.Threading.Thread.Sleep(500); }
            Console.WriteLine(fd.SelectedPath);
            destinationDirectory = fd.SelectedPath;

            
            bool recursive = MessageBox.Show(String.Format(Properties.Strings.RecursiveQuestion, locationDirectory), Properties.Strings.Subdirectories, MessageBoxButtons.YesNo) == DialogResult.Yes;

            // show the form
            using (LoadingForm loader = new LoadingForm())
            {
                new System.Threading.Thread(async () =>
                {
                    var t = new Task<IEnumerable<string>>(() => { return getImages(locationDirectory, !recursive); });
                    t.Start();
                    t.Wait();
                    files = (await t).ToList();
                    loader.Stop = true;
                }).Start();
                loader.ShowDialog();
            }
            LoadCurrent();
        }


        static List<string> extensions = new List<string>() { "JPG", "JPEG", "PNG", "BMP" };

        static IEnumerable<string> getImages(string path, bool onlyTopDirectorys)
        {
            foreach (var file in System.IO.Directory.EnumerateFiles(path, "*.*", onlyTopDirectorys ? System.IO.SearchOption.TopDirectoryOnly : System.IO.SearchOption.AllDirectories))
            {
                if (extensions.Contains(file.Split('\\').Last().Split('.').Last().ToUpper()))
                {
                    yield return file;
                }
            }
            yield break;
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            moveCurrent(files[currentIndex], destinationDirectory + "\\" + files[currentIndex].Split('\\').Last());
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            NextImage();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            PreviousImage();
        }

        private void viewBox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(files[currentIndex]);
        }

        private void SortForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Right:
                    {
                        NextImage();
                        e.Handled = true;
                        break;
                    }
                case Keys.Left:
                    {
                        PreviousImage();
                        e.Handled = true;
                        break;
                    }
                case Keys.Enter:
                    {
                        moveCurrent(files[currentIndex], destinationDirectory + "\\" + files[currentIndex].Split('\\').Last());
                        e.Handled = true;
                        break;
                    }
                case Keys.Space:
                    {
                        lock (viewBox.Image)
                        {
                            var i = (Image)viewBox.Image.Clone();
                            i.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            viewBox.Image = i;
                        }
                        e.Handled = true;
                        break;
                    }
            }
            viewBox.Focus();
        }

        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + files[currentIndex]);
        }

        private void jumpToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var nextThing = int.Parse(Microsoft.VisualBasic.Interaction.InputBox(Properties.Strings.JumpWhichImage, "", "0", -1, -1)) - 1;
                if (nextThing < 0 || nextThing > files.Count)
                {
                    throw new Exception(String.Format(Properties.Strings.NumMustBetween, 0, files.Count));
                }

                currentIndex = nextThing;
                LoadCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Strings.Error);
            }
        }
    }
}
