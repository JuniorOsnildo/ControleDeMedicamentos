using System.ComponentModel.DataAnnotations;
using ControleDeMedicamentos.Dominio.ModuloFornecedor;
using ControleDeMedicamentos.Dominio.ModuloMedicamentos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeMedicamentos.WebApp.Models;

public class CadastrarMedicamentoViewModel
{
    [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo 'Nome' deve conter entre 2 e 50 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo 'Descrição' é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo 'Descrição' deve conter entre 2 e 100 caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O campo 'Fornecedor' é obrigatório.")]
    public Guid FornecedorId { get; set; }
    public List<SelectListItem> FornecedoresDisponiveis { get; set; } = new List<SelectListItem>();

    public CadastrarMedicamentoViewModel() { }

    public CadastrarMedicamentoViewModel(List<Fornecedor> fornecedoresDisponiveis)
    {
        foreach (var f in fornecedoresDisponiveis)
        {
            var selecionarVm = new SelectListItem(f.Nome, f.Id.ToString());

            FornecedoresDisponiveis.Add(selecionarVm);
        }
    }
}

public class VisualizarMedicamentosViewModel
{
    public List<DetalhesMedicamentoViewModel> Registros { get; } = new List<DetalhesMedicamentoViewModel>();

    public VisualizarMedicamentosViewModel(List<Medicamento> medicamentos)
    {
        foreach (var med in medicamentos)
        {
            var detalhesVm = new DetalhesMedicamentoViewModel(
                med.Id,
                med.Nome,
                med.Descricao,
                med.Fornecedor.Nome,
                med.QuantidadeEmEstoque,
                med.EmFalta
            );
            
            Registros.Add(detalhesVm);
        }
    }
}

public class EditarMedicamentoViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo 'Nome' deve conter entre 2 e 50 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo 'Descrição' é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo 'Descrição' deve conter entre 2 e 100 caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O campo 'Fornecedor' é obrigatório.")]
    public Guid FornecedorId { get; set; }
    public List<SelectListItem> FornecedoresDisponiveis { get; set; } = new List<SelectListItem>();

    public EditarMedicamentoViewModel() { }

    public EditarMedicamentoViewModel(
        Guid id, 
        string nome,
        string descricao,
        Guid fornecedorId, 
        List<Fornecedor> fornecedoresDisponiveis
    )
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        FornecedorId = fornecedorId;

        foreach (var f in fornecedoresDisponiveis)
        {
            var selecionarVm = new SelectListItem(f.Nome, f.Id.ToString());

            FornecedoresDisponiveis.Add(selecionarVm);
        }
    }
}

public class ExcluirMedicamentoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public ExcluirMedicamentoViewModel() { }

    public ExcluirMedicamentoViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class DetalhesMedicamentoViewModel(
    Guid id,
    string nome,
    string descricao,
    string Fornecedor,
    int quantidadeEmEstoque,
    bool emFalta)
{
    
    public Guid Id { get; set; } = id;
    public string Nome { get; set; } = nome;
    public string Descricao { get; set; } = descricao;
    public string NomeFornecedor { get; set; } = Fornecedor;
    public int QuantidadeEmEstoque { get; set; } = quantidadeEmEstoque;
    public bool EmFalta { get; set; } = emFalta;
}