using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class CursoTest
    {

        
        [Fact]
        public void DeveCriarCurso()
        {
            //Arranje
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950,
        };

            //Action
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            //Assert
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

    }
}
