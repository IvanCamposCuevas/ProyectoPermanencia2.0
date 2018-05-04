using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPermanencia.Conexion;

namespace ProyectoPermanencia.Negocio
{
    public class Negocio
    {
        
            private Conexion.Conexion conec1;

            public Conexion.Conexion Conec1
            {
                get { return conec1; }
                set { conec1 = value; }
            }

            public void configuraConexion()
            {
                this.Conec1 = new Conexion.Conexion();
                this.Conec1.NombreBaseDeDatos = "prueba";
                this.Conec1.NombreTabla = "clientes";
                this.Conec1.CadenaConexion = "Data Source=LAPTOP-9N5AEVQ2;Initial Catalog=Permanencia_2;Integrated Security=True";
            }


            public System.Data.DataSet consultaScore(String rut, String jornada)
            {
                this.configuraConexion();
                String auxSQL = " WHERE "
           + "AL.Id_Alumno = SC.Id_Alumno"
           + " AND "
           + "AL.Id_Carrera = CA.Id_Carrera"
           + " AND "
           + "AL.Id_Sede = SE.Id_Sede"
           + " AND "
           + "AL.Id_Jornada = JO.Id_Jornada";

                //Aplicar Filtros
                if (!String.IsNullOrEmpty(rut))
                    auxSQL = auxSQL + " AND AL.Desc_Rut_Alumno = '" + rut + "';";
                else if (!String.IsNullOrEmpty(rut))
                    auxSQL = auxSQL + " AND AL.Id.Jornada = '" + jornada + "';";


            this.Conec1.IntruccioneSQL = "SELECT AL.Desc_Rut_Alumno AS Rut,"
                                               + "AL.Desc_Alumno AS Nombre,"
                                               + "CA.Desc_Carrera AS Carrera,"
                                               + "SE.Desc_Sede AS Sede,"
                                               + "JO.Desc_Jornada AS Jornada,"
                                               + "SC.Score AS Score "
                                               + "--ES.Desc_Escuela " + "\n"

                                               + " FROM "
                                               + "Permanencia_2.dbo.Score_Alumnos SC,"
                                               + "Permanencia_2.dbo.LK_Alumno AL,"
                                               + "Permanencia_2.dbo.LK_Carrera CA,"
                                               + "Permanencia_2.dbo.LK_Sede SE,"
                                               + "Permanencia_2.dbo.LK_Jornada JO"
                                               + "   --Permanencia_2.dbo.LK_Escuela ES" + "\n"
                                               + auxSQL;
                /* + " WHERE "
                 + "AL.Id_Alumno = SC.Id_Alumno"
                 + " AND "
                 + "AL.Id_Carrera = CA.Id_Carrera"
                 + " AND "
                 + "AL.Id_Sede = SE.Id_Sede"
                 + " AND "
                 + "AL.Id_Jornada = JO.Id_Jornada"; */
                //+ "--AND"
                // + "--     CA.Id_Escuela = ES.Id_Escuela";


                this.Conec1.EsSelect = true;
                this.Conec1.conectar();

                return this.Conec1.DbDat;
            } // Fin metodo entrega



            public bool validarRut(string rut)
            {

                bool validacion = false;
                try
                {
                    rut = rut.ToUpper();
                    rut = rut.Replace(".", "");
                    rut = rut.Replace("-", "");
                    int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                    char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                    int m = 0, s = 1;
                    for (; rutAux != 0; rutAux /= 10)
                    {
                        s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                    }
                    if (dv == (char)(s != 0 ? s + 47 : 75))
                    {
                        validacion = true;
                    }
                }
                catch (Exception)
                {
                }
                return validacion;
            }

            public string formatearRut(string rut)
            {
                int cont = 0;
                string format;
                if (rut.Length == 0)
                {
                    return "";
                }
                else
                {
                    rut = rut.Replace(".", "");
                    rut = rut.Replace("-", "");
                    format = "-" + rut.Substring(rut.Length - 1);
                    for (int i = rut.Length - 2; i >= 0; i--)
                    {
                        format = rut.Substring(i, 1) + format;
                        cont++;
                        if (cont == 3 && i != 0)
                        {
                            format = "." + format;
                            cont = 0;
                        }
                    }
                    return format;
                }
            }
        }
    }

