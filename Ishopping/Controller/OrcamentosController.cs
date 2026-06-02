using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ishopping.Model;

namespace Ishopping.Controller
{
    // Controlador responsável pelas operações dos orçamentos
    internal class OrcamentosController
    {
        // Carrega e mostra todos os orçamentos na tabela
        public static void MostrarOrcamentos(DataGridView grid)
        {
            // Obtém a lista de orçamentos da base de dados
            List<Orcamento> orcamentos = ObterOrcamentos();
            // Associa os dados à tabela
            grid.DataSource = orcamentos;
        }

        // Obtém todos os orçamentos da base de dados, ordenados por ano (decrescente) e mês (crescente)
        public static List<Orcamento> ObterOrcamentos()
        {
            using (IShoppingContext db = new IShoppingContext())
            {
                return db.Orcamentos
                    .OrderByDescending(o => o.Ano)
                    .ThenBy(o => o.Mes)
                    .ToList();
            }
        }

        // Adiciona um novo orçamento à base de dados
        public static void AdicionarOrcamento(string mes, string ano, string valor)
        {
            // Valida se o mês foi preenchido
            if (string.IsNullOrWhiteSpace(mes))
            {
                MessageBox.Show("Indique o mês do orçamento.");
                return;
            }

            // Valida se o ano é um número inteiro válido entre 2000 e 2100
            if (!int.TryParse(ano, out int anoInt) || anoInt <= 0 || anoInt < 2000 || anoInt > 2100)
            {
                MessageBox.Show("Indique um ano válido.");
                return;
            }

            // Valida se o valor é um número decimal válido maior que zero
            if (!decimal.TryParse(valor, out decimal valorDecimal) || valorDecimal <= 0)
            {
                MessageBox.Show("O valor máximo deve ser maior que zero.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Cria uma nova instância de orçamento com os dados fornecidos
                Orcamento orcamento = new Orcamento
                {
                    Mes = mes.Trim(),
                    Ano = anoInt,
                    ValorMaximo = valorDecimal,
                    DataCriacao = DateTime.Now,
                    CriadoPor = Sessao.UtilizadorAtual
                };

                // Adiciona o orçamento à base de dados e guarda as alterações
                db.Orcamentos.Add(orcamento);
                db.SaveChanges();

                MessageBox.Show("Orçamento adicionado com sucesso.");
            }
        }

        // Atualiza um orçamento existente na base de dados
        public static void AtualizarOrcamento(string id, string mes, string ano, string valor)
        {
            // Valida se o ID é um número inteiro válido
            if (!int.TryParse(id, out int idInt) || idInt <= 0)
            {
                MessageBox.Show("Indique um ID válido.");
                return;
            }

            // Valida se o mês foi preenchido
            if (string.IsNullOrWhiteSpace(mes))
            {
                MessageBox.Show("Indique o mês do orçamento.");
                return;
            }

            // Valida se o ano é um número inteiro válido entre 2000 e 2100
            if (!int.TryParse(ano, out int anoInt) || anoInt <= 0 || anoInt < 2000 || anoInt > 2100)
            {
                MessageBox.Show("Indique um ano válido.");
                return;
            }

            // Valida se o valor é um número decimal válido maior que zero
            if (!decimal.TryParse(valor, out decimal valorDecimal) || valorDecimal <= 0)
            {
                MessageBox.Show("O valor máximo deve ser maior que zero.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Procura o orçamento pela ID
                Orcamento orcamento = db.Orcamentos.FirstOrDefault(o => o.Id == idInt);

                // Se o orçamento não existir, mostra mensagem de erro
                if (orcamento == null)
                {
                    MessageBox.Show("Orçamento não encontrado.");
                    return;
                }

                // Atualiza os dados do orçamento
                orcamento.Mes = mes.Trim();
                orcamento.Ano = anoInt;
                orcamento.ValorMaximo = valorDecimal;
                orcamento.DataAlteracao = DateTime.Now;
                orcamento.AlteradoPor = Sessao.UtilizadorAtual;

                // Guarda as alterações na base de dados
                db.SaveChanges();

                MessageBox.Show("Orçamento atualizado com sucesso.");
            }
        }

        // Elimina um orçamento da base de dados
        public static void EliminarOrcamento(string id)
        {
            // Valida se o ID é um número inteiro válido
            if (!int.TryParse(id, out int idInt) || idInt <= 0)
            {
                MessageBox.Show("Indique um ID válido.");
                return;
            }

            using (IShoppingContext db = new IShoppingContext())
            {
                // Procura o orçamento pelo ID
                Orcamento orcamento = db.Orcamentos.FirstOrDefault(o => o.Id == idInt);

                // Se o orçamento não existir, mostra mensagem de erro
                if (orcamento == null)
                {
                    MessageBox.Show("Orçamento não encontrado.");
                    return;
                }

                // Remove o orçamento da base de dados
                db.Orcamentos.Remove(orcamento);
                // Guarda as alterações na base de dados
                db.SaveChanges();

                MessageBox.Show("Orçamento eliminado com sucesso.");
            }
        }
    }
}
