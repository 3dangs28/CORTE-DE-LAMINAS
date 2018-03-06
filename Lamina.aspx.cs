using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cortes_de_Lamina
{
    public partial class Lamina : System.Web.UI.Page
    {
        double area, areac, areaA, areaR;
        double porcentajeCorte=0, porcentajeResidual;
     
        int n, f1, c1, f2, c2, nt,nn1, nn2,nn3;
        //nvy, nvx n viejas en x  en y
        int nvy, nvx, xery, yery;
        double x1f, y1f;

        int n1, n2,nry,nrx;
        int nt1, nt2, ct, ft;
        int xe1, ye1, xe2, ye2;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["w"] == null)
                Response.End();
            //variables para calculo de residuos
            Color colorCorte = System.Drawing.ColorTranslator.FromHtml(ConfigurationManager.AppSettings["colorCorte"]);

            bool zoom1 = false;
            bool zoom2 = false;
         

            double Ry = 0;
            double Rx = 0;


            //Variable final de n, almacenada de forma entera

            int xef, yef;
           

            double yaux = Convert.ToDouble(Request["w"]);
            double xaux = Convert.ToDouble(Request["h"]);
            double y1aux = Convert.ToDouble(Request["w1"]);
            double x1aux = Convert.ToDouble(Request["h1"]);
            double y, x, y1, x1;


            if (yaux > 25 || xaux > 25)
            {
                zoom1 = true;
                yaux *= 5;
                xaux *= 5;
            }


            if ((yaux <= 25) && (xaux <= 25))
            {
                zoom2 = true;
                yaux *= 10;
                xaux *= 10;

            }

            //---forma horizontal siempre de la imagen

            if (xaux >= yaux)
            {
                x = xaux;
                y = yaux;
            }
    
            else
            {
                y = xaux;
                x = yaux;
            }



            if (x1aux >= y1aux)
            {
                x1 = x1aux;
                y1 = y1aux;
            }
     
            else
            {
                y1 = x1aux;
                x1 = y1aux;

            }


            if (zoom1)
            {
                y1 *= 5;
                x1 *= 5;
            }

            if (zoom2)
            {
                y1 *= 10;
                x1 *= 10;
            }




            Bitmap miMapa = new Bitmap((int)x, (int)y);
            Graphics g = Graphics.FromImage((System.Drawing.Image)miMapa);
            g.Clear(System.Drawing.ColorTranslator.FromHtml(ConfigurationManager.AppSettings["colorLienzo"]));

            
            //-----------Calculos matematicos iniciales
            xe1 = (int)(x / x1);
            ye1 = (int)(y / y1);
            xe2 = (int)(x / y1);
            ye2 = (int)(y / x1);

            n1 = xe1 * ye1;
            n2 = xe2 * ye2;


            //determinación del aprovechamiento maximo del area
            if (n1 >= n2)
            {
                n = n1;
                x1f = x1;
                y1f = y1;
                xef = xe1;
                yef = ye1;
                f1 = xef;
                c1 = yef;

            }
            else
            {
                n = n2;
                x1f = y1;
                y1f = x1;
                xef = xe2;
                yef = ye2;
                f1 = yef;
                c1 = xef;
            }




            //-----------bloque fusionado-----------------------------

            if ((c1 * y1f) > y)
            {
                int temx, temy;
                double temxf, temyf;
                temx = c1;
                temy = f1;
                c1 = temy;
                f1 = temx;
                //---------------------
                temyf = y1f;
                temxf = x1f;
                x1f = temyf;
                y1f = temxf;

                Ry = y - (y1f * yef);
                Rx = x - (x1f * xef);
                nn1 = c1 * f1;
                
                for (int i = 0; i < c1 * (int)x1f; i = i + (int)x1f)
                {
                    for (int j = 0; j < f1 * (int)y1f; j = j + (int)y1f)
                    {
                        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(colorCorte);
                        g.FillRectangle(myBrush, new Rectangle(j, i, (int)y1f, (int)x1f));
                        g.DrawRectangle(new Pen(Brushes.Black, -0.1f), j, i, (int)y1f, (int)x1f);
                    }
                }

            
            }
            else
            {
                Ry = y - (y1f * yef);
                Rx = x - (x1f * xef);



                if ((Ry > Rx) &&((Ry+y1f)>=(x1f)))
                {
                    xery = ((int)(x / y1f));
                    yery = (int)((Ry + y1f) / x1f);
                    nry = xery * yery;
                    nn1 = nry;
                    int yy = (int)y1f * (yef - 1);

                    if(nry>xef) {
                    for (int i = 0; i < yery * (int)x1f; i = i + (int)x1f)
                    {

                        for (int j = 0; j < xery * (int)y1f; j = j + (int)y1f)
                        {
                            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(colorCorte);
                            g.FillRectangle(myBrush, new Rectangle(j, (i+yy), (int)y1f, (int)x1f));
                            g.DrawRectangle(new Pen(Brushes.Black, -0.1f), j, (i + yy), (int)y1f, (int)x1f);
                        }
                    }
                    }
                    else
	                 {
                         for (int i = 0; i < yery * (int)y1f; i = i + (int)y1f)
                         { 
                             for (int j = 0; j < xery * (int)x1f; j = j + (int)x1f)
                        {
                            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(colorCorte);
                            g.FillRectangle(myBrush, new Rectangle(j, (i+yy), (int)x1f, (int)y1f));
                            g.DrawRectangle(new Pen(Brushes.Black, -0.1f), j, (i + yy), (int)x1f, (int)y1f);
                        }
                    }
                            
	}

                    nn2 = (c1 - 1) * f1;
                    for (int i = 0; i < (c1-1) * (int)y1f; i = i + (int)y1f)
                    {
                        for (int j = 0; j < f1 * (int)x1f; j = j + (int)x1f)
                        {
                            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(colorCorte);
                            g.FillRectangle(myBrush, new Rectangle(j, i, (int)x1f, (int)y1f));
                            g.DrawRectangle(new Pen(Brushes.Black, -0.1f), j, i, (int)x1f, (int)y1f);
                        }
                    }
                    
                }
                else{
                    nn1 = c1 * f1;
                    for (int i = 0; i < c1 * (int)y1f; i = i + (int)y1f)
                    {
                        for (int j = 0; j < f1 * (int)x1f; j = j + (int)x1f)
                        {
                            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(colorCorte);
                            g.FillRectangle(myBrush, new Rectangle(j, i, (int)x1f, (int)y1f));
                            g.DrawRectangle(new Pen(Brushes.Black, -0.1f), j, i, (int)x1f, (int)y1f);
                        }
                    }

                }


//-----------------Brutal-----enemy------------------


                if (Rx > Ry)
                {
                    if (Rx >= y1f)
                    {
                        int xet1, yet1, xet2, yet2;

                        //-----Cantidad de elementos en x,y
                        xet1 = (int)(Rx / x1f);
                        yet1 = (int)(y / y1f);

                        xet2 = (int)(Rx / y1f);
                        yet2 = (int)(y / x1f);

                        //-------numeros de elementos------
                        nt1 = xet1 * yet1;
                        nt2 = xet2 * yet2;

                        if (nt1 > nt2)
                        {
                            ct = xet1;
                            ft = yet1;

                        }
                        else
                        {
                            ct = xet2;
                            ft = yet2;
                        }

                        int yy = (int)x1f * (xef);

                        nn3 = ct * ft;
                        for (int i = 0; i < ft * (int)x1f; i = i + (int)x1f)
                        {
                            for (int j = 0; j < (ct) * (int)y1f; j = j + (int)y1f)
                            {
                                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(colorCorte);
                                g.FillRectangle(myBrush, new Rectangle((yy + j), i, (int)y1f, (int)x1f));
                                g.DrawRectangle(new Pen(Brushes.Black, -0.1f), (yy+j), i, (int)y1f, (int)x1f);
                            }
                        }


                    }

                }



            }
            nt = nn1 + nn2 + nn3;

            //------------------------------Calculos de areas------------------------
           
            if (zoom1 == true)
            {  //area total  
                area = (x * y) / 25;

                //area aprobechable
                areac = ((x1 * y1) / 25)*nt;

                //area residual
                areaR = area - areac;

            }

            if (zoom2 == true)
            {  
                //area total  
                area = (x * y) / 100;
                //area aprobechable
                areac = ((x1 * y1) / 100)*nt;

                //area residual
                areaR = area - areac;
            }

            //------------------C
            porcentajeCorte = (areac / area) * 100;
            porcentajeResidual = (areaR / area) * 100;

      
                //-----------inicio--------------visualición de resultados numericos y graficos------------------------------------------------
            g.DrawString(string.Format("area total: {0:0.0}", area), new Font(FontFamily.GenericMonospace, 15), Brushes.White, 5, 5);
            g.DrawString(string.Format("% area aprobechable: {0:0.0}", porcentajeCorte), new Font(FontFamily.GenericMonospace, 15), Brushes.White, 5, 20);
            g.DrawString(string.Format("% area residual: {0:0.0}", porcentajeResidual), new Font(FontFamily.GenericMonospace, 15), Brushes.White, 5, 35);
                g.DrawString(string.Format("Elementos: {0}", nt), new Font(FontFamily.GenericMonospace, 15), Brushes.White, 5, 50);
                g.Save();
                Response.Clear();
                Response.ClearContent();
                Response.ContentType = "Image/jpeg";
                miMapa.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

        }
    }
}