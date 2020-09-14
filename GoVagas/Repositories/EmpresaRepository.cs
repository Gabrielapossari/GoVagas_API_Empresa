using GoVagas.Contexts;
using GoVagas.Domains;
using GoVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoVagas.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        GoVagasContext ctx = new GoVagasContext();

        public List<Empresa> Listar()
        {
            // Retorna uma lista com todas as informações da empresa
            return ctx.Empresa.ToList();
        }
        /// <summary>
        /// Cadastra um novo empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto com as informações de cadastro</param>
        public void Cadastrar(Empresa novaEmpresa)
        {
            // Adiciona um novo endereco
            ctx.Empresa.Add(novaEmpresa);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }
        /// <summary>
        /// Busca uma empresa por ID
        /// </summary>
        /// <param name="id">ID da empresa que será buscado</param>
        /// <returns>Uma empresa buscada</returns>
        public Empresa BuscarPorId(int id)
        {
            return ctx.Empresa.FirstOrDefault(e => e.IdEmpresa == id);

        }
        /// <summary>
        /// Atualiza uma empresa existente
        /// </summary>
        /// <param name="id">ID da empresa  que será atualizado</param>
        /// <param name="empresaAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Empresa empresaAtualizado)
        {
            // Busca um evento através do id
            Empresa empresaBuscado = ctx.Empresa.Find(id);

            // Verifica se a empresa foi encontrada
            if (empresaBuscado.AnexarLogo != null)
            {
                // Verifica se foi informado um novo AnexarLogo para a empresa
                if (empresaAtualizado.AnexarLogo != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscado.AnexarLogo = empresaAtualizado.AnexarLogo;
                }
                // Verifica se foi informado um novo CargoArea para a empresa
                if (empresaAtualizado.CargoArea != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscado.CargoArea = empresaAtualizado.CargoArea;
                }

                // Verifica se foi informada uma novo WebSite para a empresa
                if (empresaAtualizado.WebSite != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscado.WebSite = empresaAtualizado.WebSite;
                }

                // Verifica se foi informada uma novo novo de empresa para a empresa
                if (empresaAtualizado.NomeEmpresa != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscado.NomeEmpresa = empresaAtualizado.NomeEmpresa;
                }

                // Verifica se o cnpj foi informado
                if (empresaAtualizado.Cnpj != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscado.Cnpj = empresaAtualizado.Cnpj;
                }

                // Verifica se a instituição foi informada
                if (empresaAtualizado.RamoEmpresa != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscado.RamoEmpresa = empresaAtualizado.RamoEmpresa;
                }
                // Verifica se a descricao da empresa foi informada
                if (empresaAtualizado.DescricaoEmpresa != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscado.DescricaoEmpresa = empresaAtualizado.DescricaoEmpresa;
                }
                // Verifica se a localizacao da foi informada
                if (empresaAtualizado.LocalizacaoEmpresa != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscado.LocalizacaoEmpresa = empresaAtualizado.LocalizacaoEmpresa;
                }
                // Verifica se o campo encontrou senai foi informada
                if (empresaAtualizado.EncontrouSenai != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscado.EncontrouSenai = empresaAtualizado.EncontrouSenai;
                }
                ctx.SaveChanges();
            }
        }
        public void Deletar(int id)
        {
            // Remove a empresa que foi buscado através do id informado
            ctx.Empresa.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }
    }
}
