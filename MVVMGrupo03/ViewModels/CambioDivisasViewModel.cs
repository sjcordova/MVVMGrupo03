using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMGrupo03.ViewModels
{
    public class CambioDivisasViewModel : INotifyPropertyChanged
    {

        private string _valorDolares;
        private string _valorEuros;

        public string ValorDolares {
            get => _valorDolares;
            set {
                if (_valorDolares != value)
                {
                    _valorDolares = value;
                    OnPropertyChanged();
                    CambiarDeDolaresAEuros();
                }
            }
        }

        public string ValorEuros
        {
            get => _valorEuros;
            set
            {
                if (_valorEuros != value)
                {
                    _valorEuros = value;
                    OnPropertyChanged();
                }
            }
        }

        public void CambiarDeDolaresAEuros()
        {
            try
            {
                var cambio = Double.Parse(ValorDolares) * 0.93;
                ValorEuros = $"{cambio:F2}";
            }
            catch (Exception)
            {
                ValorEuros = "Dato Incorrecto";
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
