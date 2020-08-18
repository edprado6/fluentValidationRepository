using System;
using FluentValidation.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidation.Tests
{
    [TestClass]
    public class UsuarioTest
    {
        private UsuarioService _usuarioService;

        public UsuarioTest()
        {
            _usuarioService = new UsuarioService();
        }

        [TestMethod]
        public void GetById()
        {
            var result = _usuarioService.GetById(1);
        }
    }
}
