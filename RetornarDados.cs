using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ApiAutoGlass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetornarDados : ControllerBase
    {

        private readonly IConfiguration _configurcao;
        public RetornarDados(IConfiguration configuracao)
        {
            _configurcao = configuracao;
        }

        [HttpGet]

        public JsonResult Get()

        {
            string query = @"
                            SELECT P.IDPROD, P.NOMEPROD, DATE_FORMAT(P.DATAFAB,'%d/ %m/ %Y') AS DATAFAB, DATE_FORMAT(P.DATAVAL,'%d/ %m/ %Y') AS DATAVAL, P.CODIGOFORN, F.DESCRICAO, F.CIDADE
                            FROM PRODUTOS P INNER JOIN FORNECEDORES F ON (P.CODIGOFORN = F.IDFORN)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurcao.GetConnectionString("ApiCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();

                }
            }

            return new JsonResult(table);

        }
    }

}
