using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica_Coches_AWS.Models;
using Practica_Coches_AWS.Repositories;
using Practica_Coches_AWS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Practica_Coches_AWS.Controllers
{
    public class CochesController : Controller
    {
        public RepositoryCoches repo;
        public ServiceAWSS3 service;

        public CochesController(RepositoryCoches repo, ServiceAWSS3 service)
        {
            this.service = service;
            this.repo = repo;
        }

        public IActionResult IndexServidor()
        {
            List<Coche> coches = this.repo.GetCoches();

            return View(coches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(int idCoche,string marca, string conductor, IFormFile file)
        {
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, file.FileName);
            }

            this.repo.InsertarCoche(idCoche, marca, conductor, file.FileName);
            return RedirectToAction("IndexServidor");
        }



    }
}
