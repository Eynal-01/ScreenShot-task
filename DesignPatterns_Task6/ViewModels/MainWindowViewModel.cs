using DesignPatterns_Task6.Commands;
using DesignPatterns_Task6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesignPatterns_Task6.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand TakeScreenshotCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand ForwardCommand { get; set; }

        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            var originator = new Originator(ImageSource);
            var careTaker = new CareTaker(originator);

            TakeScreenshotCommand = new RelayCommand((t) =>
            {
                //var bitmap = ScreenCapture.CaptureWindow(new IntPtr());
                var bitmap = ScreenCapture.CaptureDesktop();
                var result = Converter.ImageSourceFromBitmap(bitmap);
                ImageSource = result;
                originator.SetState(ImageSource);
                careTaker.Backup();
            });

            BackCommand = new RelayCommand((b) => 
            {
                var imageSource = careTaker.Undo();
                if (imageSource != null)
                    ImageSource = imageSource;
            });

            ForwardCommand = new RelayCommand((b) =>
            {
                var imageSource = careTaker.Redo();
                if (imageSource != null)
                    ImageSource = imageSource;
            });
        }
    }
}
