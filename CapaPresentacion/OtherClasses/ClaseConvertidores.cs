using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaPresentacion.OtherClasses
{
    public class ClaseConvertidores
    {
        //public static string NumeroaLetra(double CantidadNumerica)
        //{
        //    string[] cifras1 = { "", "UNO ", "DOS ", "TRES ", "CUATRO ", "CINCO ", "SEIS ", "SIETE ", "OCHO ", "NUEVE ", "", "ONCE ", "DOCE ", "TRECE ", "CATORCE ", "QUINCE ", "DIECISEIS ", "DIECISIETE ", "DIECIOCHO ", "DIECINUEVE "};
        //    string[] cifras2 = {  "", "DIEZ ", "VEINTE ", "TREINTA ", "CUARENTA ", "CINCUENTA ", "SESENTA ", "SETENTA ", "OCHENTA ", "NOVENTA "};
        //    string[] cifras3 = {  "", "CIENTO ", "DOCIENTOS ", "TRECIENTOS ", "CUATROCIENTOS ", "QUINIENTOS ", "SEISCIENTOS ", "SETECIENTOS ", "OCHOCIENTOS ", "NOVECIENTOS "};

        //    int[] arr = new int[10];
        //    arr[0] = 0;
        //    string letras = "";
        //    string strNumeroEnLetras;

        //    int i = 0;
        //    int k = 0;
        //    int f = 0;
        //    int q = 0;
        //    int c = 0;
        //    int a = 0;
        //    int b = 0, m = 0;
        //    double h;
        //    ///////////////////////////////////////////////
        //    h = CantidadNumerica;
        //    b = Convert.ToInt32(h*100);
        //    m = b % 100;//capturo el entro del residuo
        //    a = (b - m) / 100;
        //    c = a;
        //    f = a.ToString().Length;
        //    for (i = 1; i <= f; i++)
        //    {
        //        arr[i] = c % 10;
        //        c = c - arr[i];
        //        c = c / 10;
        //    }

        //    for (i = f; i > 0; i--)
        //    {
        //        switch (i)
        //        {
        //            case 6:
        //                if ((arr[i] == 1) && (arr[i - 2] == 0) && (arr[i - 1] == 0))
        //                {
        //                    letras =  "CIEN ";
        //                    k = 1;
        //                    i = i - 2;
        //                }
        //                else
        //                if (arr[i] != 0)
        //                {
        //                    letras =  String.Concat(letras.ToString(), cifras3[arr[i]].ToString());
        //                    k = 1;
        //                }
        //                break;
        //            case 5:
        //                if ((arr[i] != 0) && (arr[i - 1] == 0))
        //                {
        //                    letras = String.Concat(letras.ToString(), cifras2[arr[i]].ToString());
        //                    i = i - 1;
        //                    k = 1;
        //                }
        //                else
        //                    if ((arr[i] == 2) && (arr[i] != 0))
        //                {
        //                    letras = String.Concat(letras.ToString(), "VEINTI ");
        //                    k = 1; q = 2;
        //                }

        //                else
        //                    if ((arr[i] == 1) && (arr[i] != 0))
        //                {
        //                    letras = String.Concat(letras.ToString(), cifras1[arr[i - 1] + 10].ToString());
        //                    i = i - 1;
        //                    k = 1;
        //                }
        //                else
        //                        if ((arr[i] != 0))
        //                {
        //                    letras = String.Concat(letras.ToString(), cifras2[arr[i]].ToString());
        //                    k = 1;
        //                    q = 1;
        //                }

        //                break;
        //            case 4:
        //                if ((arr[i] != 0) && (q == 1))
        //                {
        //                    letras = String.Concat(letras.ToString(), "Y ");
        //                    k = 1;
        //                }
        //                if ((arr[i] == 1) && (q == 2))
        //                {
        //                    letras = String.Concat(letras.ToString(), "UN ");
        //                    k = 1;
        //                }

        //                else if (arr[i] == 1 && k == 1)
        //                {
        //                    letras = String.Concat(letras.ToString(), "UN ");
        //                    k = 1;
        //                }
        //                else
        //                    if (arr[i] != 1)
        //                {
        //                    letras = String.Concat(letras.ToString(), cifras1[arr[i]].ToString());
        //                    k = 1;
        //                }

        //                else if (arr[i] == 1)
        //                    k = 1;

        //                break;
        //            case 3:
        //                if (k == 1)
        //                {
        //                    letras = String.Concat(letras.ToString(), "MIL ");
        //                }
        //                if ((arr[i] == 1) && (arr[i - 2] == 0) && (arr[i - 1] == 0))
        //                {
        //                    letras = String.Concat(letras.ToString(), "CIEN ");
        //                    k = 1;
        //                    i = i - 2;
        //                    k = 1;
        //                }
        //                else
        //                   if (arr[i] != 0)
        //                {
        //                    letras = String.Concat(letras.ToString(), cifras3[arr[i]].ToString());
        //                    k = 1;
        //                }
        //                break;
        //            case 2:
        //                if ((arr[i] != 0) && (arr[i - 1] == 0))
        //                {
        //                    letras = String.Concat(letras.ToString(), cifras2[arr[i]].ToString());
        //                    i = i - 1;
        //                }
        //                else
        //                    if (arr[i] == 2 && arr[i] != 0)
        //                {
        //                    letras = String.Concat(letras.ToString(), "VIENTI ");
        //                }
        //                else
        //                        if ((arr[i] == 1) && (arr[i] != 0))
        //                {
        //                    letras = String.Concat(letras.ToString(), cifras1[arr[i - 1] + 10].ToString());
        //                    i = i - 1;
        //                    k = 2;
        //                }
        //                else
        //                    if (arr[i] != 0)
        //                {
        //                    letras = String.Concat(letras.ToString(), cifras2[arr[i]].ToString());
        //                    k = 2;
        //                }
        //                break;
        //            case 12:
        //                if ((arr[i] != 0) && (k == 2))
        //                {
        //                    letras = String.Concat(letras.ToString(), "Y ", cifras1[arr[i]].ToString());
        //                }
        //                else
        //                    if (arr[i] != 0)
        //                {
        //                    letras = String.Concat(letras.ToString(), cifras1[arr[i]].ToString());
        //                }
        //                break;
        //        }
        //    }
        //    if (a == 0)
        //    {
        //        letras =  "CERO";//'La cadena letras es el resultado;
        //    }
        //    strNumeroEnLetras = String.Concat("SON: ", letras.ToString(), " Y ", m.ToString("00"));//para menajar diferentes tipos de monedas cuando esta funcion sea llamada en la factura
        //    return strNumeroEnLetras;
        //}
        public static string NumToLetter(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try

            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString("00") + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return "SON: " + res + " NUEVOS SOLES";
        }
        private static string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }
    }
}