using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using calculator.Classes;
using SQLite;


namespace calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Process : ContentPage
    {
        private int Organico;
        private int Cantidad;
        private string Action;

        private bool Pvalue; // alto o bajo Fosforo // Valores Booleanos para el Fosforo y el Potasio
        private bool Kvalue; // Alto o bajo Potasio
        private int Nvalue; // 

        private float MedidasSAcos;





        // Para poder asignar a la variable orgánica del suelo.
        public int _Organico { set { Organico = value;  } get { return Organico; } }

        public string _ACtion { set { Action = value; } get { return Action; } }

        public int _Cantidad { set { Cantidad = value; } get { return Cantidad; } }

        public int _Nvalue { set { Nvalue = value; } get { return Nvalue; } }




        public Process()
        {
            InitializeComponent();
        }

        private void BtnElegirCultivo_Clicked(object sender, EventArgs e)
        {

            try
            {
                Organico = int.Parse(ValOrganico.Text);
                if ((Organico >= 0) && (Organico <= 5))
                {
                    
                    
                    //DisplayAlert("info", "ok", "ok");
                    BtnElegirCultivo.IsEnabled = false;
                    ValOrganico.IsEnabled = false;


                }
                else
                {
                    DisplayAlert("info", "Debe ser un valor entre 0 y 5", "ok");
                }
            }
            catch (Exception)
            {
                DisplayAlert("info", "debe ser un valor entero no negativo", "ok");
            }
            
        }

        /*private void BtnNitrogenoValue_Clicked(object sender, EventArgs e)
        {
            try
            {
                Nvalue = int.Parse(EntNitrogeno.Text);
                if (Nvalue > 0)
                {
                    EntNitrogeno.IsEnabled = false;
                    BtnNitrogenoValue.IsEnabled = false;
                }
                else
                {
                    DisplayAlert("info", "Debe ser un valor positivo", "ok");
                }
            }
            catch (Exception)
            {
                DisplayAlert("info", "debe ser un valor entero no negativo", "ok");
            }

            
        }

        async void BtnUbicacion_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Lugar de ubicación de las parselas", "Cancel", null, "Guayas", "Manabi", "Esmeraldas");

            Action = action;
            LblUbicacion.Text = Action;
            await DisplayAlert("info","Usted ha seleccionado "+action,"ok");
            BtnUbicacion.IsEnabled = false;
            LblUbicacion.IsEnabled = false;

        }*/





        private void BtnAltoFosforo_Clicked(object sender, EventArgs e)
        {
            Pvalue = true;
            LblFrm1Fosforo.Text = "7 % de Fosforo";
            LblFrm2Fosforo.Text = "7 % de Fosforo";
            LblFrm3Fosforo.Text = "7 % de Fosforo";
            BtnBajoFosforo.IsEnabled = false;

        }

        private void BtnBajoFosforo_Clicked(object sender, EventArgs e)
        {
            Pvalue = false;
            LblFrm1Fosforo.Text = "14 % de Fosforo";
            LblFrm2Fosforo.Text = "14 % de Fosforo";
            LblFrm3Fosforo.Text = "14 % de Fosforo";
            BtnAltoFosforo.IsEnabled = false;
        }

        private void BtnAltoPotasio_Clicked(object sender, EventArgs e)
        {
            Kvalue = true;
            LblFrm1Potasio.Text = "7 % de Potasio";
            LblFrm2Potasio.Text = "7 % de Potasio";
            LblFrm3Potasio.Text = "7 % de Potasio";
            BtnBajoPotasio.IsEnabled = false;
        }

        private void BtnBajoPotasio_Clicked(object sender, EventArgs e)
        {
            Kvalue = false;
            LblFrm1Potasio.Text = "14 % de Potasio";
            LblFrm2Potasio.Text = "14 % de Potasio";
            LblFrm3Potasio.Text = "14 % de Potasio";
            BtnAltoPotasio.IsEnabled = false;
        }

        



        

        private void BtnRefresh_Clicked(object sender, EventArgs e)
        {
            BtnAltoFosforo.IsEnabled = true;
            BtnBajoFosforo.IsEnabled = true;
            BtnAltoPotasio.IsEnabled = true;
            BtnBajoPotasio.IsEnabled = true;

        }

        private void BtnCantidadEsperada_Clicked(object sender, EventArgs e)
        {
            try
            {
                Cantidad = int.Parse(CantidadEsperada.Text);
                if (Cantidad > 499)
                {
                    
                    CantidadEsperada.IsEnabled = false;
                    BtnCantidadEsperada.IsEnabled = false;
                    if (Organico > 2)
                    {
                           
                        MedidasSAcos = ((100 *Cantidad)/22) /1000;
                        LblFrm1.Text = MedidasSAcos.ToString() + " Lbs de Medida";
                        DisplayAlert("ok", MedidasSAcos.ToString()+" Lbs de Medida", "ok");

                    }
                    else if (Organico == 2)
                    {
                        
                        MedidasSAcos = ((100 / 12) * (Cantidad ))/1000;
                        LblFrm2.Text = MedidasSAcos.ToString();
                        DisplayAlert("ok", MedidasSAcos.ToString(), "ok");
                    }
                    else
                    {
                        
                        MedidasSAcos = ((100 / 7) * (Cantidad))/1000;
                        LblFrm3.Text = MedidasSAcos.ToString() + " Lbs de Medida";
                        DisplayAlert("ok", MedidasSAcos.ToString() + " Lbs de Medida", "ok");

                    }
                }
                else
                {
                    DisplayAlert("info", "Los valores esperados de cosecha deben ser mayores a 500 Kg/Ha ", "ok");
                }

            }
            catch (Exception)
            {
                DisplayAlert("info", "Campo debe contener un valor numérico", "ok");
            }
        }


        

        private void BtnOkCalculo_Clicked(object sender, EventArgs e)
        {
            calculate calc = new calculate()
            {

                ValorOrganico = Organico,
                //MedidaNitrogeno = Nvalue,
                CosechaValue = Cantidad,
                MedidaFosforo = Pvalue,
                MedidaPotasio = Kvalue,
                MedidaSacoFertilizante = MedidasSAcos
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<calculate>();
                int rowsAdd = conn.Insert(calc);
                
            }
            DisplayAlert("info", "Valores agregados correctamente", "ok");
            if (Organico > 2)
            {
                FrameWherever.IsVisible = true;
                FrameWherever2.IsVisible = false;
                FrameWherever3.IsVisible = false;
                //MedidasSAcos = ((1 / 22) * 100) * (Cantidad / 1000);
                //LblFrm1.Text = MedidasSAcos.ToString();

            }
            else if (Organico == 2)
            {
                FrameWherever2.IsVisible = true;
                FrameWherever.IsVisible = false;
                FrameWherever3.IsVisible = false;
                //MedidasSAcos = ((1 / 12) * 100) * (Cantidad / 1000);
                //LblFrm2.Text = MedidasSAcos.ToString();
            }
            else
            {
                FrameWherever2.IsVisible = false;
                FrameWherever.IsVisible = false;
                FrameWherever3.IsVisible = true;
                //MedidasSAcos = ((1 / 7) * 100) * (Cantidad / 1000);
                //LblFrm3.Text = MedidasSAcos.ToString();
            }

            

        }

        private void BtnReinicio_Clicked(object sender, EventArgs e)
        {
            EnableAllWidgets();
        }

        // ========================================= METHODZ ==========================================================


        private void EnableAllWidgets()
        {
            // FRame 1
            BtnElegirCultivo.IsEnabled = true;
            ValOrganico.IsEnabled = true;

            // Frame 2
            //BtnUbicacion.IsEnabled = true;
            //EntNitrogeno.IsEnabled = true;
            //BtnNitrogenoValue.IsEnabled = true;
            //LblUbicacion.IsEnabled = true;
            //LblUbicacion.Text = "";

            // Frame 3

            BtnAltoFosforo.IsEnabled = true;
            BtnBajoFosforo.IsEnabled = true;
            BtnAltoPotasio.IsEnabled = true;
            BtnBajoPotasio.IsEnabled = true;

            // Frame 4
            CantidadEsperada.IsEnabled = true;
            BtnCantidadEsperada.IsEnabled = true;


        }


        private void MedidaVAlues_22(int pies)  // Cuando el Nitrogeno tiene 22% de cantidad en los sacos
        {
            //MedidasSAcos = 0;
            MedidasSAcos = ((1/22)*100)*(pies / 1000);
            //Sacos = (4.55)(pies/1000);

        }

        private void MedidaVAlues_12(int pies)  // Cuando el Nitrogeno tiene 12% de cantidad en los sacos
        {
            //MedidasSAcos = 0;
            MedidasSAcos = ((1 / 12) * 100) * (pies / 1000);
            //float Sacos = 0;
        }

        private void MedidaVAlues_7(int pies)  // Cuando el Nitrogeno tiene 7% de cantidad en los sacos
        {
            //MedidasSAcos = 0;
            MedidasSAcos = ((1 / 7) * 100) * (pies / 1000);
            //float Sacos = 0;
        }


    }
}