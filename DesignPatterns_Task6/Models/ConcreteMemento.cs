using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesignPatterns_Task6.Models
{
    public class ConcreteMemento : IMemento
    {
        private ImageSource _state;

        public ConcreteMemento(ImageSource state)
        {
            _state = state;
        }

        public ImageSource GetImageSource()
        {
          return this._state;
        }
    }
}
