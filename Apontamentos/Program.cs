using System;

DateTime hoje = DateTime.Today;

Console.WriteLine("Por favor, digite a data que você deseja apontar (formato: AAAA-MM-DD):");
string entrada = Console.ReadLine();

if (DateTime.TryParse(entrada, out DateTime dataParaApontar))
{
    bool podeApontar = PodeApontarParaData(hoje, dataParaApontar);

    Console.WriteLine(podeApontar
        ? $"Você PODE apontar para a data {dataParaApontar.ToShortDateString()}."
        : $"Você NÃO PODE apontar para a data {dataParaApontar.ToShortDateString()}.");
}
else
{
    Console.WriteLine("Inválido, use o formato: AAAA-MM-DD");
}

bool PodeApontarParaData(DateTime hoje, DateTime dataParaApontar)
{
    DateTime inicioDaSemanaAtual = hoje.AddDays(-(int)hoje.DayOfWeek); //pega o domingo atual

    DateTime inicioDaSemanaAnterior = inicioDaSemanaAtual.AddDays(-7); //pega o domingo passado -7 dias

    DateTime fimDaSemanaAtual = inicioDaSemanaAtual.AddDays(7); //pega o próximo domingo +7 dias

    bool dentroDaSemanaAtual = dataParaApontar >= inicioDaSemanaAtual && dataParaApontar < fimDaSemanaAtual;

    bool dentroDaSemanaAnterior = (hoje.DayOfWeek == DayOfWeek.Monday || hoje.DayOfWeek == DayOfWeek.Tuesday) &&
                                  dataParaApontar >= inicioDaSemanaAnterior && dataParaApontar < inicioDaSemanaAtual;

    return dentroDaSemanaAtual || dentroDaSemanaAnterior;
}