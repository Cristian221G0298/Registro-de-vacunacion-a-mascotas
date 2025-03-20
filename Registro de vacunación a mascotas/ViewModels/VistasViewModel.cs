using GalaSoft.MvvmLight.Command;
using Registro_de_vacunación_a_mascotas.Models;
using Registro_de_vacunación_a_mascotas.Repositories;
using Registro_de_vacunación_a_mascotas.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Registro_de_vacunación_a_mascotas.ViewModels
{
    public class VistasViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        VistasRepository repos = new();

        public ICommand InicioCommand { get; set; }
        public ICommand HistorialCommand { get; set; }
        public ICommand MascotasMasVacunasCommand { get; set; }
        public ICommand VacunasAplicadasHaceDiasCommand {  get; set; }
        public ICommand MascotasSinAplicarseVacunasCommand { get; set; }
        public ICommand MascotasSinTodasVacunasCommand { get; set; }
        public ICommand VacunasSinAplicarCommand {  get; set; }

        public UserControl Vista { get; set; } = new();
        public List<Vwhistorialvacunas> Historial { get; set; } = new();
        public List<Vwmascotasconmasvacunas> MascotasConMasVacunas { get; set; } = new();
        public List<Vwregistro> VacunasAplicadasHaceDiasL { get; set; } = new();
        public List<Vwmascotasvacunasfaltantes> MascotasConVacunasFaltantes { get; set; } = new();
        public List<Vwmascotassinvacunas> MascotasSinVacunas { get; set; } = new();
        public List<Vwvacunassinaplicar> VacunasSinAplicarL { get; set; } = new();

        public VistasViewModel()
        {
            InicioCommand = new RelayCommand(Inicio);
            HistorialCommand = new RelayCommand(HistorialV);
            MascotasMasVacunasCommand = new RelayCommand(MascotasMasVacunas);
            VacunasAplicadasHaceDiasCommand = new RelayCommand(VacunasAplicadasHaceDias);
            MascotasSinAplicarseVacunasCommand = new RelayCommand(MascotasSinAplicarseVacunas);
            MascotasSinTodasVacunasCommand = new RelayCommand(MascotasSinTodasVacunas);
            VacunasSinAplicarCommand = new RelayCommand(VacunasSinAplicar);
            Inicio();
        }
        InicioView inicio = new();
        private void Inicio()
        {
            Vista = inicio;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        HistorialView historial = new();
        private void HistorialV()
        {
            Vista = historial;
            Historial = repos.HistorialVacunas().ToList();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        MascotasMasVacunasView mascotasMasVacunas = new();
        private void MascotasMasVacunas()
        {         
            Vista = mascotasMasVacunas;
            MascotasConMasVacunas = repos.MascotasConMásVacunas().ToList();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        VacunasAplicadasHaceDiasView vacunas = new();
        private void VacunasAplicadasHaceDias()
        {         
            Vista = vacunas;
            VacunasAplicadasHaceDiasL = repos.VacunasAplicadasHaceDias().ToList();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        MascotasSinAplicarseVacunasView mascotas = new();
        private void MascotasSinAplicarseVacunas()
        {
            Vista = mascotas;
            MascotasSinVacunas = repos.MascotasSinVacunas().ToList();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        MascotasSinTodasSusVacunasView mascotasVacunasFaltantes = new();
        private void MascotasSinTodasVacunas()
        {
            Vista = mascotasVacunasFaltantes;
            MascotasConVacunasFaltantes = repos.MascotasVacunasFaltantes().ToList();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        VacunasSinAplicarView vacunasSinAplicar = new();
        private void VacunasSinAplicar()
        {
            Vista = vacunasSinAplicar;
            VacunasSinAplicarL = repos.VacunasSinAplicar().ToList();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
