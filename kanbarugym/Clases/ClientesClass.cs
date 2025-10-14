﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace kanbarugym.Clases
{
    public class ClientesClass : INotifyPropertyChanged
    {
        public required string Id { get; set; }
        public required string Nombres { get; set; }
        public required string FechaNacimiento { get; set; }
        public required string CorreoElectronico { get; set; }
        public required string Telefono { get; set; }
        public required string Sexo { get; set; }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded == value) return;
                _isExpanded = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
