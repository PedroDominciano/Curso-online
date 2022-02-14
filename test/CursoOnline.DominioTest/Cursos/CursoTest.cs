using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
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
                PublicoAlvo = "Estudante",
                Valor = (double)950,
        };

            //Action
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            //Assert
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }

        [Fact]
        public void DeveGerarErroCasoInformarAlgoEmBranco()
        {
            //Arranje
            const string nome = "";
            const double cargaHoraria = 0;
            const string publicoAlvo = "";
            const double valor = 0;

            //Action
            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);
            var bInformacesValidas = curso.ValidarInformacoes();

            //Assert
            Assert.False(bInformacesValidas);

        }
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, string publicoAlvo, double valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public bool ValidarInformacoes()
        {
            return ((Nome != "") && (CargaHoraria != 0) && (PublicoAlvo != "") && (Valor != 0));
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

    }
}
