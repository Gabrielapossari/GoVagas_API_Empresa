using GoVagas.Contexts;
using GoVagas.Domains;
using GoVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoVagas.Repositories
{
    public class EmpresaRepository : IImpresaRepository
    {
        GoVagasContext ctx = new GoVagasContext();

        public void Atualizar(int id, Empresa EmpresaAtualizado)
        {
            // Busca um evento através do id
            Empresa empresaBuscada = ctx.Empresa.Find(id);

            // Verifica se a empresa foi encontrada
            if (empresaBuscada.AnexarLogo != null)
            {
                // Verifica se foi informado um novo AnexarLogo para a empresa
                if (EmpresaAtualizado.AnexarLogo != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscada.AnexarLogo = EmpresaAtualizado.AnexarLogo;
                }
                // Verifica se foi informado um novo CargoArea para a empresa
                if (EmpresaAtualizado.CargoArea != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscada.CargoArea = EmpresaAtualizado.CargoArea;
                }

                // Verifica se foi informada uma novo WebSite para a empresa
                if (EmpresaAtualizado.WebSite != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscada.WebSite = EmpresaAtualizado.WebSite;
                }

                // Verifica se foi informada uma novo novo de empresa para a empresa
                if (EmpresaAtualizado.NomeEmpresa != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscada.NomeEmpresa = EmpresaAtualizado.NomeEmpresa;
                }

                // Verifica se o cnpj foi informado
                if (EmpresaAtualizado.Cnpj != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscada.Cnpj = EmpresaAtualizado.Cnpj;
                }

                // Verifica se a instituição foi informada
                if (EmpresaAtualizado.RamoEmpresa != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscada.RamoEmpresa = EmpresaAtualizado.RamoEmpresa;
                }
                // Verifica se a descricao da empresa foi informada
                if (EmpresaAtualizado.DescricaoEmpresa != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscada.DescricaoEmpresa = EmpresaAtualizado.DescricaoEmpresa;
                }
                // Verifica se a localizacao da foi informada
                if (EmpresaAtualizado.LocalizacaoEmpresa != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscada.LocalizacaoEmpresa = EmpresaAtualizado.LocalizacaoEmpresa;
                }
                // Verifica se o campo encontrou senai foi informada
                if (EmpresaAtualizado.EncontrouSenai != null)
                {
                    // Atribui o novo valor ao campo
                    empresaBuscada.EncontrouSenai = EmpresaAtualizado.EncontrouSenai;
                }
                ctx.SaveChanges();
            }
        }


        public Empresa BuscarPorId(int id)
        {
            return ctx.Empresa.FirstOrDefault(ca => ca.IdEmpresa == id);
        }

        public void Cadastrar(Empresa novoEmpresa)
        {
            // Adiciona um nova nova empresa
            ctx.Empresa.Add(novoEmpresa);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Empresa empresaBuscada = ctx.Empresa.Find(id);
            ctx.Empresa.Remove(empresaBuscada);
            ctx.SaveChanges();
        }

        public List<Empresa> ListarTodos()
        {
            return ctx.Empresa.ToList();
        }
    }
}
