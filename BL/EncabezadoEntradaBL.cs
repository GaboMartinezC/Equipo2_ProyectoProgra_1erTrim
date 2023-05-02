﻿using DAL;
using ET;
using System.Data;
//using System.Data.SqlClient
namespace BL
{
    public class EncabezadoEntradaBL
    {
        //genera una instancia que permite acceder a los métodos de EncabezadoEntradaDAL
        private EncabezadoEntradaDAL dal = new EncabezadoEntradaDAL();
        public bool IngresarEntrada(EncabezadoEntrada encabezado)
        {
            //Valor de retorno
            bool retVal = true;
            // Instancia una datatable que se llena con los datos existentes en BD 
            DataTable listaEntradas = dal.VerTodoRegistroEntradas();
            //Variable temporal que guarda los datos a validar
            string descripcion = "";
            for (int i = 0; i < listaEntradas.Rows.Count; i++)
            {
                //Llena la string de descripcion con la consulta y la compara con el nuevo registro
                //Si este se encuentra, el valor de retorno es falso
                descripcion = listaEntradas.Rows[i]["ID"].ToString();
                if (encabezado.Id.Equals(descripcion))
                    retVal = false;
                descripcion = listaEntradas.Rows[i]["IdEMPLEADO"].ToString();
                if (encabezado.IdEmpleado.Equals(descripcion))
                    retVal = false;
            }
            if (retVal)
                retVal = dal.IngresarEntrada(encabezado);
            return retVal;

        }

        public bool BorrarRegistroEntrada(int idEncabezado)
        {
            //Valor de retorno
            bool retVal = false;
            // Instancia una datatable que se llena con los datos existentes en BD de los autores
            DataTable listaEntradas = dal.VerTodoRegistroEntradas();
            //Variable temporal que guarda los datos a validar
            string descripcion = "";
            for (int i = 0; i < listaEntradas.Rows.Count; i++)
            {
                //recorrido a la lista de autores
                descripcion = listaEntradas.Rows[i][idEncabezado].ToString();
                if (idEncabezado.Equals(descripcion))
                {
                    retVal = true;
                }
            }
            //retorna true en caso de que el id haya sido encontrado para seguidamente borrarlo
            if (retVal)
                retVal = dal.BorrarRegistroEntrada(idEncabezado);
            return retVal;
        }

        public bool ActualizarEntrada(EncabezadoEntrada entrada)
        {
            bool retVal = false;
            DataTable listaEntradas = dal.VerTodoRegistroEntradas();
            string descripcion = "";
            for (int i = 0; i < listaEntradas.Rows.Count; i++)
            {
                //Consulta si hay la entrada existe para retonar verdadero y acceder a dal
                descripcion = listaEntradas.Rows[i]["ID"].ToString();
                if (entrada.Id.Equals(descripcion))
                    retVal = true;
            }
            if (retVal)
                retVal = dal.ActualizarEntrada(entrada);
            return retVal;

        }

        /*Los metodos tipo DataTable solo van a retornar una instancia a los metodos
        correspondientes de dal ya que,
        no necesita confirmar existencia, solo mostrarla*/
        public DataTable VerTodoRegistroEntradas()
        {
            return dal.VerTodoRegistroEntradas();
        }
        //busca las entradas por fecha
        public DataTable BuscarEntradasFecha(DateOnly fecha)
        {
            return dal.BuscarEntradasFecha(fecha);
        }
    }
}
