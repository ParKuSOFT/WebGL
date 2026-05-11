using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using WebGL.Models;

namespace WebGL.Controllers
{
    /// <summary>
    /// Контроллер для получения данных куба (вершины, нормали, цвета, индексы)
    /// </summary>
    [ApiController]
    public class CubeDataController : ControllerBase
    {
        /// <summary>
        /// GET: /api/cubedata
        /// Возвращает данные куба (вершины, нормали, цвета, индексы)
        /// </summary>
        [HttpGet("/api/cubedata/1")]
        [Produces("application/json")]
        public IActionResult GetCubeData()
        {
            Model3DRepository repo = new Model3DRepository(@"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=D:\db2.accdb;");

            var cubeData = new CubeDataResponse
            {
                Vertices = repo.GetVertices(1),
                Normals = repo.GetNormalsGradient(1), // Используем новые нормали для градиента
                Colors = repo.GetColors(1),
                Indices = repo.GetIndices(1)
            };
            repo.Close();
            return Ok(cubeData);
        }
        [HttpGet("/api/cubedata/2")]
        [Produces("application/json")]
        public IActionResult GetOctahedronData()
        {
            Model3DRepository repo = new Model3DRepository(@"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=D:\db2.accdb;");

            var cubeData = new CubeDataResponse
            {
                Vertices = repo.GetVertices(2),
                Normals = repo.GetNormalsGradient(2), // Используем новые нормали для градиента
                Colors = repo.GetColors(2),
                Indices = repo.GetIndices(2)
            };
            repo.Close();
            return Ok(cubeData);
        }
        [HttpGet("/api/cubedata/3")]
        [Produces("application/json")]
        public IActionResult GetBipiramidData()
        {
            Model3DRepository repo = new Model3DRepository(@"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=D:\db2.accdb;");

            var cubeData = new CubeDataResponse
            {
                Vertices = repo.GetVertices(3),
                Normals = repo.GetNormalsGradient(3), // Используем новые нормали для градиента
                Colors = repo.GetColors(3),
                Indices = repo.GetIndices(3)
            };
            repo.Close();
            return Ok(cubeData);
        }
    }


    /// <summary>
    /// данные куба
    /// </summary>
    public class CubeDataResponse
    {
        [JsonPropertyName("vertices")]
        public List<float> Vertices { get; set; } = new();

        [JsonPropertyName("normals")]
        public List<float> Normals { get; set; } = new();

        [JsonPropertyName("colors")]
        public List<float> Colors { get; set; } = new();

        [JsonPropertyName("indices")]
        public List<int> Indices { get; set; } = new();
    }
}
