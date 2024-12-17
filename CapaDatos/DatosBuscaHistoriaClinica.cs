using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;

namespace CapaDatos
{
  public  class DatosBuscaHistoriaClinica
    {
        public static List<EntidadBuscaHistoriaClinica> BuscarHistoriaClinica(int numero_admision)
        {
            List<EntidadBuscaHistoriaClinica> lst = new List<EntidadBuscaHistoriaClinica>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "spHistoriaClinica";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@numero_admision", SqlDbType.Int)).Value = numero_admision;
                  
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int ficha = 0;
                            ficha = Convert.ToInt32(dr["col0"]);
                            if(ficha == 1)
                            {
                                EntidadBuscaHistoriaClinica entFicha1 = new EntidadBuscaHistoriaClinica()
                                {
                                    Ficha1_col0 = dr["col0"].ToString(),
                                    Ficha1_col1 = dr["col1"].ToString(),
                                    Ficha1_col2 = dr["col2"].ToString(),
                                    Ficha1_col3 = dr["col3"].ToString(),
                                    Ficha1_col4 = dr["col4"].ToString(),
                                    Ficha1_col5 = dr["col5"].ToString(),
                                    Ficha1_col6 = dr["col6"].ToString(),
                                    Ficha1_col7 = dr["col7"].ToString(),
                                    Ficha1_col8 = dr["col8"].ToString(),
                                    Ficha1_col9 = dr["col9"].ToString(),
                                    Ficha1_col10 = dr["col10"].ToString(),
                                    Ficha1_col11 = dr["col11"].ToString(),
                                    Ficha1_col12 = dr["col12"].ToString(),
                                    Ficha1_col13 = dr["col13"].ToString(),
                                    Ficha1_col14 = dr["col14"].ToString(),
                                    Ficha1_col15 = dr["col15"].ToString(),
                                    Ficha1_col16 = dr["col16"].ToString(),
                                    Ficha1_col17 = dr["col17"].ToString()
                                };
                                lst.Add(entFicha1);
                            }
                            else if(ficha==2)
                            {
                                EntidadBuscaHistoriaClinica entFicha2 = new EntidadBuscaHistoriaClinica()
                                {
                                    Ficha2_col0 = dr["col0"].ToString(),
                                    Ficha2_col1 = dr["col1"].ToString(),
                                    Ficha2_col2 = dr["col2"].ToString(),
                                    Ficha2_col3 = dr["col3"].ToString(),
                                    Ficha2_col4 = dr["col4"].ToString(),
                                    Ficha2_col5 = dr["col5"].ToString(),
                                    Ficha2_col6 = dr["col6"].ToString(),
                                    Ficha2_col7 = dr["col7"].ToString(),
                                    Ficha2_col8 = dr["col8"].ToString(),
                                    Ficha2_col9 = dr["col9"].ToString(),
                                    Ficha2_col10 = dr["col10"].ToString(),
                                    Ficha2_col11 = dr["col11"].ToString(),
                                    Ficha2_col12 = dr["col12"].ToString(),
                                    Ficha2_col13 = dr["col13"].ToString(),
                                    Ficha2_col14 = dr["col14"].ToString(),
                                    Ficha2_col15 = dr["col15"].ToString(),
                                    Ficha2_col16 = dr["col16"].ToString(),
                                    Ficha2_col17 = dr["col17"].ToString(),
                                    Ficha2_col18 = dr["col18"].ToString(),
                                    Ficha2_col19 = dr["col19"].ToString(),
                                    Ficha2_col20 = dr["col20"].ToString(),
                                    Ficha2_col21 = dr["col21"].ToString(),
                                    Ficha2_col22 = dr["col22"].ToString()

                                };
                                lst.Add(entFicha2);
                            }
                            else if(ficha==3)
                            {
                                EntidadBuscaHistoriaClinica entFicha3 = new EntidadBuscaHistoriaClinica()
                                {
                                    Ficha3_col0 = dr["col0"].ToString(),
                                    Ficha3_col1 = dr["col1"].ToString(),
                                    Ficha3_col2 = dr["col2"].ToString(),
                                    Ficha3_col3 = dr["col3"].ToString(),
                                    Ficha3_col4 = dr["col4"].ToString(),
                                    Ficha3_col5 = dr["col5"].ToString(),
                                    Ficha3_col6 = dr["col6"].ToString(),
                                    Ficha3_col7 = dr["col7"].ToString(),
                                    Ficha3_col8 = dr["col8"].ToString(),
                                    Ficha3_col9 = dr["col9"].ToString(),
                                    Ficha3_col10 = dr["col10"].ToString(),
                                    Ficha3_col11 = dr["col11"].ToString(),
                                    Ficha3_col12 = dr["col12"].ToString(),
                                    Ficha3_col13 = dr["col13"].ToString(),
                                    Ficha3_col14 = dr["col14"].ToString(),
                                    Ficha3_col15 = dr["col15"].ToString(),
                                    Ficha3_col16 = dr["col16"].ToString(),
                                    Ficha3_col17 = dr["col17"].ToString(),
                                    Ficha3_col18 = dr["col18"].ToString(),
                                    Ficha3_col19 = dr["col19"].ToString(),
                                    Ficha3_col20 = dr["col20"].ToString()
 
                                };
                                lst.Add(entFicha3);
                            }
                            else if(ficha==4)
                            {
                                EntidadBuscaHistoriaClinica entFicha4 = new EntidadBuscaHistoriaClinica()
                                {
                                    Ficha4_col0 = dr["col0"].ToString(),
                                    Ficha4_col1 = dr["col1"].ToString(),
                                    Ficha4_col2 = dr["col2"].ToString(),
                                    Ficha4_col3 = dr["col3"].ToString(),
                                    Ficha4_col4 = dr["col4"].ToString(),
                                    Ficha4_col5 = dr["col5"].ToString(),
                                    Ficha4_col6 = dr["col6"].ToString(),
                                    Ficha4_col7 = dr["col7"].ToString(),
                                    Ficha4_col8 = dr["col8"].ToString(),
                                    Ficha4_col9 = dr["col9"].ToString(),
                                    Ficha4_col10 = dr["col10"].ToString(),
                                    Ficha4_col11 = dr["col11"].ToString(),
                                    Ficha4_col12 = dr["col12"].ToString(),
                                    Ficha4_col13 = dr["col13"].ToString(),
                                    Ficha4_col14 = dr["col14"].ToString(),
                                    Ficha4_col15 = dr["col15"].ToString(),
                                    Ficha4_col16 = dr["col16"].ToString(),
                                    Ficha4_col17 = dr["col17"].ToString(),
                                    Ficha4_col18 = dr["col18"].ToString()
                                };
                                lst.Add(entFicha4);
                            }
                            else if(ficha==5)
                            {
                                EntidadBuscaHistoriaClinica entFicha5 = new EntidadBuscaHistoriaClinica()
                                {
                                    Ficha5_col0 = dr["col0"].ToString(),
                                    Ficha5_col1 = dr["col1"].ToString(),
                                    Ficha5_col2 = dr["col2"].ToString(),
                                    Ficha5_col3 = dr["col3"].ToString(),
                                    Ficha5_col4 = dr["col4"].ToString(),
                                    Ficha5_col5 = dr["col5"].ToString(),
                                    Ficha5_col6 = dr["col6"].ToString(),
                                    Ficha5_col7 = dr["col7"].ToString(),
                                    Ficha5_col8 = dr["col8"].ToString(),
                                    Ficha5_col9 = dr["col9"].ToString(),
                                    Ficha5_col10 = dr["col10"].ToString(),
                                    Ficha5_col11 = dr["col11"].ToString(),
                                    Ficha5_col12 = dr["col12"].ToString(),
                                    Ficha5_col13 = dr["col13"].ToString(),
                                    Ficha5_col14 = dr["col14"].ToString(),
                                    Ficha5_col15 = dr["col15"].ToString(),
                                    Ficha5_col16 = dr["col16"].ToString(),
                                    Ficha5_col17 = dr["col17"].ToString(),
                                    Ficha5_col18 = dr["col18"].ToString(),
                                    Ficha5_col19 = dr["col19"].ToString(),
                                    Ficha5_col20 = dr["col20"].ToString()
                                };
                                lst.Add(entFicha5);
                            }
                            else if(ficha==6)
                            {
                                EntidadBuscaHistoriaClinica entFicha6 = new EntidadBuscaHistoriaClinica()
                                {
                                    Ficha6_col0 = dr["col0"].ToString(),
                                    Ficha6_col1 = dr["col1"].ToString(),
                                    Ficha6_col2 = dr["col2"].ToString(),
                                    Ficha6_col3 = dr["col3"].ToString(),
                                    Ficha6_col4 = dr["col4"].ToString(),
                                    Ficha6_col5 = dr["col5"].ToString(),
                                    Ficha6_col6 = dr["col6"].ToString(),
                                    Ficha6_col7 = dr["col7"].ToString(),
                                    Ficha6_col8 = dr["col8"].ToString(),
                                    Ficha6_col9 = dr["col9"].ToString(),
                                    Ficha6_col10 = dr["col10"].ToString(),
                                    Ficha6_col11 = dr["col11"].ToString(),
                                    Ficha6_col12 = dr["col12"].ToString(),
                                    Ficha6_col13 = dr["col13"].ToString(),
                                    Ficha6_col14 = dr["col14"].ToString(),
                                    Ficha6_col15 = dr["col15"].ToString(),
                                    Ficha6_col16 = dr["col16"].ToString(),
                                    Ficha6_col17 = dr["col17"].ToString(),
                                    Ficha6_col18 = dr["col18"].ToString(),
                                    Ficha6_col19 = dr["col19"].ToString()
                                };
                                lst.Add(entFicha6);
                            }
                            else if(ficha==7)
                            {
                                EntidadBuscaHistoriaClinica entFicha7 = new EntidadBuscaHistoriaClinica()
                                {
                                    Ficha7_col0 = dr["col0"].ToString(),
                                    Ficha7_col1 = dr["col1"].ToString(),
                                    Ficha7_col2 = dr["col2"].ToString(),
                                    Ficha7_col3 = dr["col3"].ToString(),
                                    Ficha7_col4 = dr["col4"].ToString(),
                                    Ficha7_col5 = dr["col5"].ToString(),
                                    Ficha7_col6 = dr["col6"].ToString(),
                                    Ficha7_col7 = dr["col7"].ToString(),
                                    Ficha7_col8 = dr["col8"].ToString(),
                                    Ficha7_col9 = dr["col9"].ToString(),
                                    Ficha7_col10 = dr["col10"].ToString(),
                                    Ficha7_col11 = dr["col11"].ToString(),
                                    Ficha7_col12 = dr["col12"].ToString()
                                };
                                lst.Add(entFicha7);
                            }
                            else if(ficha==8)
                            {
                                EntidadBuscaHistoriaClinica entFicha8 = new EntidadBuscaHistoriaClinica()
                                {
                                    Ficha8_col0 = dr["col0"].ToString(),
                                    Ficha8_col1 = dr["col1"].ToString(),
                                    Ficha8_col2 = dr["col2"].ToString(),
                                    Ficha8_col3 = dr["col3"].ToString(),
                                    Ficha8_col4 = dr["col4"].ToString(),
                                    Ficha8_col5 = dr["col5"].ToString(),
                                    Ficha8_col6 = dr["col6"].ToString(),
                                    Ficha8_col7 = dr["col7"].ToString(),
                                    Ficha8_col8 = dr["col8"].ToString(),
                                    Ficha8_col9 = dr["col9"].ToString(),
                                    Ficha8_col10 = dr["col10"].ToString(),
                                    Ficha8_col11 = dr["col11"].ToString(),
                                    Ficha8_col12 = dr["col12"].ToString(),
                                    Ficha8_col13 = dr["col13"].ToString(),
                                    Ficha8_col14 = dr["col14"].ToString(),
                                    Ficha8_col15 = dr["col15"].ToString(),
                                    Ficha8_col16 = dr["col16"].ToString(),
                                    Ficha8_col17 = dr["col17"].ToString(),
                                    Ficha8_col18 = dr["col18"].ToString(),
                                    Ficha8_col19 = dr["col19"].ToString(),
                                    Ficha8_col20 = dr["col20"].ToString(),
                                    Ficha8_col21 = dr["col21"].ToString()
                                };
                                lst.Add(entFicha8);
                            }
                            
                        }
                    }

                }

            }
            return lst;
        }
    }
}
