using Gerenciador.Context;
using Gerenciador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador.Controllers
{
    public class AlunoController : Controller
    {
        private readonly Contexto _context;
        public AlunoController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.aluno.Where(a=>a.idUsuario == User.Identity.Name).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            var Aaluno = new Aluno
            {
                Nome = aluno.Nome,
                Disciplina = aluno.Disciplina,
                Descricao = aluno.Descricao,
                Tema = aluno.Tema,
                Integrantes = aluno.Integrantes,
                idUsuario = User.Identity.Name,
                tipoPasta = "privada"
            };
            _context.Add(Aaluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ContentPaste(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var verifica = await _context.aluno.FindAsync(id);

            if (verifica.idUsuario !=User.Identity.Name)
            {
                return RedirectToAction("Index");
            }
            var conteudo = await _context.FilesOnDatabase.Where(a=>a.idUsuario == verifica.idUsuario).ToListAsync();
            return View(conteudo);
        }
    }
}
