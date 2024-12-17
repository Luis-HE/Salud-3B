using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using CapaEntidad;
namespace CapaDatos
{
   public class DatosModeloBuscaPacAdmitido
    {
        public static List<EntidadModeloBuscaPacAdmitido> ListPacientesAdmitidos(string dni_cliente, string fecha_admision)
        {
            List<EntidadModeloBuscaPacAdmitido> lst = new List<EntidadModeloBuscaPacAdmitido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select TBL_CLIENTE_PERSONA.numero_doc_cliente as num_doc_cliente , apellido_paterno+' '+apellido_materno+' '+nombres AS paciente,ISNULL(direccion,'') AS direccion,codigo_item_catalogo,descripcion_item,precio_atendido AS p_unitario,precio_atendido AS p_venta,1 AS cantidad, TBL_ADMISION.numero_admision as num_admision,observacion, id_grupo,id_clase from TBL_CLIENTE_PERSONA INNER JOIN(TBL_ADMISION inner JOIN TBL_ADMISION_DETALLE ON TBL_ADMISION.numero_admision = TBL_ADMISION_DETALLE.numero_admision) ON TBL_CLIENTE_PERSONA.numero_doc_cliente = TBL_ADMISION.numero_doc_cliente where TBL_ADMISION.numero_admision = (SELECT MAX(numero_admision) FROM TBL_ADMISION WHERE numero_doc_cliente='"+dni_cliente+"') AND TBL_CLIENTE_PERSONA.numero_doc_cliente = '" + dni_cliente+ "' AND CONVERT(VARCHAR(10),fecha_admision,103)= '"+fecha_admision+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            EntidadModeloBuscaPacAdmitido entModPacAdm = new EntidadModeloBuscaPacAdmitido()
                            {
                                num_doc_cliente = dr["num_doc_cliente"].ToString(),
                                paciente = dr["paciente"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                cod_item_catalogo = dr["codigo_item_catalogo"].ToString(),
                                descripcion_item = dr["descripcion_item"].ToString(),
                                p_unitario = Convert.ToDecimal(dr["p_unitario"]),
                                p_venta = Convert.ToDecimal(dr["p_venta"]),
                                cantidad = Convert.ToInt32(dr["cantidad"]),
                                numero_admision = Convert.ToInt32(dr["num_admision"]),
                                observacion =  dr["observacion"].ToString(),
                                id_grupo= Convert.ToInt32(dr["id_grupo"]),
                                id_clase = Convert.ToInt32(dr["id_clase"])
                            };
                            lst.Add(entModPacAdm);
                        }
                    }

                }

            }
                return lst;
           
        }
        public static List<EntidadModeloBuscaPacAdmitido> BuscarPacientesAdmitidosEmergencia(int dia, int mes, int anio)
        {
            List<EntidadModeloBuscaPacAdmitido> lst = new List<EntidadModeloBuscaPacAdmitido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select TBL_ADMISION.numero_admision,tipo_admision, TBL_CLIENTE_PERSONA.numero_doc_cliente,apellido_paterno+' '+apellido_materno+' '+nombres as paciente,fecha_nace, genero  from ((TBL_CLIENTE_PERSONA inner join TBL_ADMISION on TBL_CLIENTE_PERSONA.numero_doc_cliente=TBL_ADMISION.numero_doc_cliente) INNER JOIN TBL_DOCUMENTO_CONTABLE ON TBL_ADMISION.numero_admision= TBL_DOCUMENTO_CONTABLE.numero_admision) LEFT JOIN TBL_HC_EM_ATENCION_EMERGENCIA ON TBL_ADMISION.numero_admision = TBL_HC_EM_ATENCION_EMERGENCIA.numero_admision where TBL_HC_EM_ATENCION_EMERGENCIA.numero_admision IS NULL AND tipo_admision = 'Emergencia' AND day(fecha_admision) = '" + dia+ "' and MONTH(fecha_admision) = '" + mes + "' and YEAR(fecha_admision) = '" + anio + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAdmitido entModPacAdm = new EntidadModeloBuscaPacAdmitido()
                            {
                                 numero_admision = Convert.ToInt32(dr["numero_admision"]),
                                 tipo_admision= dr["tipo_admision"].ToString(),
                                 num_doc_cliente = dr["numero_doc_cliente"].ToString(),
                                 paciente = dr["paciente"].ToString(),
                                 fecha_nace = dr["fecha_nace"].ToString(),
                                 genero = dr["genero"].ToString()
                            };
                            lst.Add(entModPacAdm);
                        }
                    }

                }

            }
            return lst;

        }
        public static List<EntidadModeloBuscaPacAdmitido> BuscarPacientesAdmitidosConsultorio(int dia,int mes,int anio,int cod_especialidad)
        {
            List<EntidadModeloBuscaPacAdmitido> lst = new List<EntidadModeloBuscaPacAdmitido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"select TBL_ADMISION.numero_admision,numero_historia_clinica,TBL_CLIENTE_PERSONA.numero_doc_cliente,apellido_paterno+' '+apellido_materno+' '+nombres as paciente , descripcion_item,tipo_admision,fecha_nace,TBL_CLIENTE_PERSONA.genero,TBL_CLIENTE_PERSONA.grupo_etnico,id_ubigeo,grupo_sanguineo,TBL_TRIAJE.edad,TBL_ACOMPANANTE.id_reg_acompanante,TBL_ACOMPANANTE.nombre_acompanante+' '+ISNULL(TBL_ACOMPANANTE.apellido_acompanante,'') AS acompanante , talla, peso ,presion_arterial_sistolica,presion_arterial_diastolica,frecuencia_cardiaca,temperatura, indice_masa_cuerpo,frecuencia_respiratoria,sp_oxigeno  from 
                                 TBL_ACOMPANANTE INNER JOIN( TBL_TRIAJE INNER JOIN(TBL_CLIENTE_PERSONA INNER JOIN (TBL_ADMISION inner join TBL_ADMISION_DETALLE on TBL_ADMISION.numero_admision=TBL_ADMISION_DETALLE.numero_admision) ON TBL_CLIENTE_PERSONA.numero_doc_cliente=TBL_ADMISION.numero_doc_cliente) ON TBL_TRIAJE.numero_admision= TBL_ADMISION.numero_admision) ON TBL_ACOMPANANTE.id_reg_acompanante= TBL_ADMISION.id_reg_acompanante
                                 where dAY(fecha_admision)='" + dia+"' AND MONTH(fecha_admision)='"+mes+"' AND YEAR(fecha_admision)='"+ anio + "' AND codigo_especialidad='"+ cod_especialidad + "' AND estado='Admitido' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAdmitido entModPacAdm = new EntidadModeloBuscaPacAdmitido()
                            {
                                numero_admision = Convert.ToInt32(dr["numero_admision"]),
                                num_hist_clinica =  dr["numero_historia_clinica"].ToString(),
                                num_doc_cliente =  dr["numero_doc_cliente"].ToString(),
                                paciente = dr["paciente"].ToString(),
                                descripcion_item = dr["descripcion_item"].ToString(),
                                tipo_admision = dr["tipo_admision"].ToString(),
                                fecha_nace = dr["fecha_nace"].ToString(),
                                genero = dr["genero"].ToString(),
                                grupo_etnico = dr["grupo_etnico"].ToString(),
                                ubigeo = dr["id_ubigeo"].ToString(),
                                grupo_sanguineo = dr["grupo_sanguineo"].ToString(),
                                edad = Convert.ToInt32(dr["edad"]),
                                id_reg_acompanante = Convert.ToInt32(dr["id_reg_acompanante"]),
                                nombre_acompanante = dr["acompanante"].ToString(),
                                talla = dr["talla"].ToString(),
                                peso = dr["peso"].ToString(),
                                presion_sistolica= dr["presion_arterial_sistolica"].ToString(),
                                presion_diastolica = dr["presion_arterial_diastolica"].ToString(),
                                frecuencia_cardiaca = dr["frecuencia_cardiaca"].ToString(),
                                temperatura = dr["temperatura"].ToString(),
                                indice_masa_cuerpo = dr["indice_masa_cuerpo"].ToString(),
                                frecuencia_respiratoria = dr["frecuencia_respiratoria"].ToString(),
                                sp_oxigeno = dr["sp_oxigeno"].ToString()                               

                            };
                            lst.Add(entModPacAdm);
                        }
                    }

                }

            }
            return lst;

        }

        public static List<EntidadModeloBuscaPacAdmitido> BuscarPacientesAdmitidosRadiologia(int dia, int mes, int anio)
        {
            List<EntidadModeloBuscaPacAdmitido> lst = new List<EntidadModeloBuscaPacAdmitido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = @"SELECT TBL_ADMISION.numero_admision as num_admin,fecha_admision,nombre_especialidad,descripcion_item, tipo_admision, tipo_paciente, apellido_paterno+' '+apellido_materno+' '+nombres as paciente, direccion,fecha_nace,grupo_sanguineo FROM TBL_CLIENTE_PERSONA INNER JOIN(TBL_ESPECIALIDAD INNER JOIN(TBL_ADMISION INNER JOIN TBL_DET_ADMISION ON TBL_ADMISION.numero_admision = TBL_ADMISION_DETALLE.numero_admision) ON TBL_ESPECIALIDAD.codigo_especialidad = TBL_ADMISION_DETALLE.codigo_especialidad) ON TBL_CLIENTE_PERSONA.numero_doc_cliente=TBL_ADMISION.numero_doc_cliente 
                               WHERE day(fecha_admision) = '" + dia + "' and MONTH(fecha_admision) = '" + mes + "' and YEAR(fecha_admision) = '" + anio + "' and TBL_ADMISION_DETALLE.codigo_especialidad IN(SELECT codigo_especialidad from TBL_ESPECIALIDAD where nombre_especialidad like '%Radiolo%') AND estado='Admitido' ORDER BY fecha_admision ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAdmitido entModPacAdm = new EntidadModeloBuscaPacAdmitido()
                            {
                                numero_admision = Convert.ToInt32(dr["num_admin"]),
                                fecha_admision = dr["fecha_admision"].ToString(),
                                nombre_especialidad = dr["nombre_especialidad"].ToString(),
                                descripcion_item = dr["descripcion_item"].ToString(),
                                tipo_admision = dr["tipo_admision"].ToString(),
                                tipo_paciente = dr["tipo_paciente"].ToString(),
                                paciente = dr["paciente"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                fecha_nace = dr["fecha_nace"].ToString(),
                                grupo_sanguineo = dr["grupo_sanguineo"].ToString()
                            };
                            lst.Add(entModPacAdm);
                        }
                    }

                }

            }
            return lst;

        }
        public static List<EntidadModeloBuscaPacAdmitido> GetListPacienteTriaje(int num_admision)
        {
            List<EntidadModeloBuscaPacAdmitido> lst = new List<EntidadModeloBuscaPacAdmitido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "SELECT TBL_CLIENTE_PERSONA.numero_doc_cliente,apellido_paterno +' '+apellido_materno+' '+nombres as paciente,TBL_TRIAJE.edad,direccion,telefono2,email FROM TBL_CLIENTE_PERSONA INNER JOIN TBL_TRIAJE ON TBL_CLIENTE_PERSONA.numero_doc_cliente= TBL_TRIAJE.numero_doc_cliente where numero_admision='" + num_admision + "' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAdmitido entcp = new EntidadModeloBuscaPacAdmitido()
                            {
                                num_doc_cliente = dr["numero_doc_cliente"].ToString(),
                                paciente = dr["paciente"].ToString(),                                
                                edad = Convert.ToInt32(dr["edad"]),
                                direccion = dr["direccion"].ToString(),
                                telefono = dr["telefono2"].ToString(),
                                email = dr["email"].ToString()                               
 
                            };
                            lst.Add(entcp);
                        }
                    }

                }

            }
            return lst;
        }
        public static List<EntidadModeloBuscaPacAdmitido> BuscarPacienteAdmitidoLibroEmergencia(int dia, int mes, int anio)
        {
            List<EntidadModeloBuscaPacAdmitido> lst = new List<EntidadModeloBuscaPacAdmitido>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "select TBL_ADMISION.numero_admision,tipo_admision, TBL_CLIENTE_PERSONA.numero_doc_cliente,apellido_paterno + ' ' + apellido_materno + ' ' + nombres as paciente,fecha_nace, TBL_CLIENTE_PERSONA.genero,direccion from ((TBL_CLIENTE_PERSONA inner join TBL_ADMISION on TBL_CLIENTE_PERSONA.numero_doc_cliente = TBL_ADMISION.numero_doc_cliente) INNER JOIN TBL_DOCUMENTO_CONTABLE ON TBL_ADMISION.numero_admision = TBL_DOCUMENTO_CONTABLE.numero_admision) LEFT JOIN TBL_HC_EM_LIBRO_EMERGENCIA ON TBL_ADMISION.numero_admision = TBL_HC_EM_LIBRO_EMERGENCIA.numero_admision where TBL_HC_EM_LIBRO_EMERGENCIA.numero_admision IS NULL AND tipo_admision = 'Emergencia' AND day(fecha_admision) = '" + dia +"' and MONTH(fecha_admision) = '"+mes+"' and YEAR(fecha_admision) = '"+anio+"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntidadModeloBuscaPacAdmitido entModPacAdm = new EntidadModeloBuscaPacAdmitido()
                            {
                                numero_admision = Convert.ToInt32(dr["numero_admision"]),
                                tipo_admision = dr["tipo_admision"].ToString(),
                                num_doc_cliente = dr["numero_doc_cliente"].ToString(),
                                paciente = dr["paciente"].ToString(),
                                fecha_nace = dr["fecha_nace"].ToString(),
                                genero = dr["genero"].ToString(),
                                direccion = dr["direccion"].ToString()
                            };
                            lst.Add(entModPacAdm);
                        }
                    }

                }

            }
            return lst;
        }
        public static void ActualizaEstadoAdmision(int numero_admision)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                string query = "UPDATE TBL_ADMISION_DETALLE SET estado='Atendido' WHERE numero_admision='"+numero_admision +"' ";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
