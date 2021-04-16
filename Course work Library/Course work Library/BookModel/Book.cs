using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Course_work_Library.BookModel
{
    public class Book
    {
        public string imgPath { get; set; }
        public string PATH_pdf { get; set; }
        public Book()
        {

        }
        public Book(string author, string title, ushort yearOfPublication)
            {
                Author = author;
                Title = title;
                YearOfPublication = yearOfPublication;
            }
            private string _author;
            private string _title;
            private ushort _yearOfPublication;
            public string Author
            {
                get => _author;
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        _author = value;
                    }
                }
            }
            public string Title
            {
                get => _title;
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        _title = value;
                    }
                }
            }
            public ushort YearOfPublication
            {
                get => _yearOfPublication;
                set
                {
                    if (value > 0)
                    {
                        _yearOfPublication = value;
                    }
                }
            }
        public void OpenBookInBrowser()
        {
            try
            {
                Process.Start(PATH_pdf);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    imgPath = imgPath.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {PATH_pdf}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", PATH_pdf);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", PATH_pdf);
                }
                else
                {
                    throw;
                }
            }
        }
        public override string ToString()
        {
            return $"Title : {Title}   Author : {Author}";
        }
    }
    }

