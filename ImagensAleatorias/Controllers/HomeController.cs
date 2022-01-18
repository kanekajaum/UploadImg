using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ImagensAleatorias.Controllers
{
    public class HomeController : Controller
    {
        ImagensAleatoriasEntities2 db = new ImagensAleatoriasEntities2();
        public ActionResult Index()
        {
            //if (Session["Login"] == null)
            //{
            //    return RedirectToAction("../Login");
            //}

            var lista = db.Postagem.ToList();
            return View(lista);
        }

        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Postagem postagem)
        {
            if (postagem.imagemUpload != null)
            {
                string nomeImagem = Path.GetFileName(postagem.imagemUpload.FileName);
                var path = Path.Combine(Server.MapPath("../Upload"), nomeImagem);
                postagem.imagemUpload.SaveAs(path);

                Postagem post = new Postagem();
                post.url = nomeImagem;
                post.titulo = postagem.titulo;
                post.descricao = postagem.descricao;
                post.idUsuario = 1;
                db.Postagem.Add(post);
                db.SaveChanges();
            }
           return RedirectToAction("Index");
        }

        public ActionResult Listar()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("../Login");
                ViewBag.messagem = "Para ver a lista de Imagens é preciso efetuar o login ou se cadastrar!";
            }
            else
            {
                var lista = db.Postagem.ToList();
                return View(lista);
            }
        }

        public ActionResult Details(int id)
        {
           var imagem = db.Postagem.Where(a => a.id.Equals(id)).FirstOrDefault();
           return View(imagem);
        }

    }
}