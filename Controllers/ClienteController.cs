using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Data;
using System.Web;
using Dapper;
using System.Web.Mvc;
using System.Data.SqlClient;
using DapperMerybettAvila.Models;


namespace DapperMerybettAvila.Controllers
{
    public class ClienteController : Controller
    {        
        private string connection = "Server=Meryjean18; Database=Tienda; Integrated Security = true";
        
        public ActionResult Index()
        {

            IEnumerable<Cliente_model> lista = new List<Cliente_model>();
            using (IDbConnection conexion = new SqlConnection(connection))
            {
                conexion.Open();
                var sql = "Select * From Cliente";
                lista = conexion.Query<Cliente_model>(sql);

            }

            return View(lista);            
        }

        public ActionResult Editar(int id)
        {
            IEnumerable<Cliente_model> lista = new List<Cliente_model>();
            using (IDbConnection conexion = new SqlConnection(connection))
            {
                conexion.Open();
                var sql = "Select * From Cliente Where IdCliente =" + id;
                lista = conexion.Query<Cliente_model>(sql);
            }
            return View(lista);
        }
        [HttpPost]
        public ActionResult Editar(Cliente_model modelo)
        {
            int result = 0;
            using (IDbConnection conexion = new SqlConnection(connection))
            {
                conexion.Open();
                var sql = "Update Cliente Set  NroDocumento = @NroDocumento,Nombre =@Nombre,Direccion =@Direccion,Telefono=@Telefono" +
                    " where IdCliente = @IdCliente";
                result = conexion.Execute(sql, modelo);
            }
            return RedirectToAction("index");
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Cliente_model model)
        {
            int result = 0;
            using (IDbConnection conexion = new SqlConnection(connection))
            {
                conexion.Open();
                var sql = "Insert into Cliente(NroDocumento,Nombre,Direccion,Telefono)" +
                    "values(@NroDocumento,@Nombre,@Direccion,@Telefono)";

                result = conexion.Execute(sql, model);
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Eliminar(Cliente_model modelo, int id)
        {
            int result = 0;
            using (IDbConnection conexion = new SqlConnection(connection))
            {
                conexion.Open();
                var sql = "Delete From Cliente Where IdCliente =" + id;

                result = conexion.Execute(sql, modelo);
            }
            return RedirectToAction("index");
        }



    }
}