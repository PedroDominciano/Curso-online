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

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            //Arranje
            var cursoEsperado = new
            {
                Nome = nomeInvalido,
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950,
            };

            //Assert/Action
            var message = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;

            Assert.Equal("Nome Inválido", message);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(0.99)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            //Arranje
            var cursoEsperado = new
            {
                Nome = "Informatica",
                CargaHoraria = cargaHorariaInvalida,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950,
            };

            //Assert/Action
            var message = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;

            Assert.Equal("Carga horária Inválida", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(0.99)]
        public void NaoDeveCursoTerValorMenorQue1(double valorInvalido)
        {
            //Arranje
            var cursoEsperado = new
            {
                Nome = "Informatica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = valorInvalido,
            };

            //Assert/Action
            var message = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;

            Assert.Equal("Valor Inválido", message);
        }
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome Inválido");
            if (cargaHoraria < 1) throw new ArgumentException("Carga horária Inválida");
            if (valor < 1) throw new ArgumentException("Valor Inválido");

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
