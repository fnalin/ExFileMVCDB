using ExFileMVCDB.Models;
using System.IO;
using System.Web.Mvc;

namespace ExFileMVCDB.Controllers
{
    public class HomeController : Controller
    {
        private ExFileMVCDBContext _ctx;

        public HomeController()
        {
            _ctx = new ExFileMVCDBContext();
        }

        public ActionResult Index()
        {
            var dados = _ctx.Arquivos;
            return View(dados);
        }

        public ActionResult EnviarArquivo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarArquivo(FormCollection form)
        {
            if (Request.Files.Count != 1)
            {
                return View();
            }

            var post = Request.Files[0];

            if (post == null)
            {
                return View();
            }

            var obj = new Arquivo();

            var file = new FileInfo(post.FileName);
            obj.Nome = file.Name;
            obj.AnexoExtensao = file.Extension;
            obj.AnexoTipo = post.ContentType;

            using (var reader = new BinaryReader(post.InputStream))
                obj.AnexoBytes = reader.ReadBytes(post.ContentLength);


            _ctx.Arquivos.Add(obj);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplicação criada para teste";
            return View();
        }

       
        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}