using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoVagas.Domains;
using GoVagas.Interfaces;
using GoVagas.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GoVagas.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes a empresa
    /// </summary>
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto empresaRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IEmpresaRepository _empresaRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }
        /// <summary>
        /// Lista todas as empresas
        /// </summary>
        /// <returns>Uma lista de eventos e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de empresas</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_empresaRepository.Listar());
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Cadastra uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Empresa novaEmpresa)
        {
            try
            {
                // Faz a chamada para o método
                _empresaRepository.Cadastrar(novaEmpresa);

                // Retora a resposta da requisição 201 - Created
                return StatusCode(201);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Busca uma empresa através do ID
        /// </summary>
        /// <param name="id">ID da empresa que será buscado</param>
        /// <returns>Uma empresa buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma empresa buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto empresaBuscado
                Empresa empresaBuscado = _empresaRepository.BuscarPorId(id);

                // Verifica se a empresa foi encontrado
                if (empresaBuscado != null)
                {
                    // Retora a resposta da requisição 200 - OK e a empresa que foi encontrado
                    return Ok(empresaBuscado);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhuma empresa encontrada para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Atualiza uma empresa existente
        /// </summary>
        /// <param name="id">ID da empresa que será atualizado</param>
        /// <param name="empresaAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa/id
        [HttpPatch("{id}")]
        public IActionResult Put(int id, Empresa empresaAtualizado)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto eventoBuscado
                Empresa empresaBuscado = _empresaRepository.BuscarPorId(id);

                // Verifica se o evento foi encontrado
                if (empresaBuscado != null)
                {
                    // Faz a chamada para o método
                    _empresaRepository.Atualizar(id, empresaAtualizado);

                    // Retora a resposta da requisição 204 - No Content
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhuma empresa encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
        /// <summary>
        /// Deleta uma empresa
        /// </summary>
        /// <param name="id">ID da empresa que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        /// dominio/api/Empresa/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto empresaBuscado
                Empresa empresaBuscado = _empresaRepository.BuscarPorId(id);

                // Verifica se a empresa foi encontrado
                if (empresaBuscado != null)
                {
                    // Faz a chamada para o método
                    _empresaRepository.Deletar(id);

                    // Retora a resposta da requisição 202 - Accepted
                    return StatusCode(202);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhuma empresa foi encontrada para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }


    }
}

