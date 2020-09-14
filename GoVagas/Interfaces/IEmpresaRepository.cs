using GoVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoVagas.Interfaces
{
    interface IEmpresaRepository
    {
        /// <summary>
        /// Lista todas as empresas
        /// </summary>
        /// <returns>Uma lista de empresas</returns>
        List<Empresa> Listar();
        /// <summary>
        /// Cadastra uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto com as informações de cadastro</param>
        void Cadastrar(Empresa novaEmpresa);
        /// <summary>
        /// Busca uma empresa por ID
        /// </summary>
        /// <param name="id">ID da empresa que será buscado</param>
        /// <returns>Uma empresa buscada</returns>
        Empresa BuscarPorId(int id);
        /// <summary>
        /// Atualiza uma empresa existente
        /// </summary>
        /// <param name="id">ID da empresa que será atualizado</param>
        /// <param name="empresaAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Empresa empresaAtualizado);
        /// <summary>
        /// Deleta uma empresa
        /// </summary>
        /// <param name="id">ID da empresa que será deletado</param>
        void Deletar(int id);

    }
}
