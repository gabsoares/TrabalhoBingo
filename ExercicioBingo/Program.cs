/*
 Vamos desenvolver um jogo?

Simples, um jogo de bingo.

As regras do bingo são as seguintes:

- As cartelas possuem 25 números escritos em ordem aleatória.

- Os números sorteados vão de 1 a 99.

- Se algum jogador completar uma linha a pontuação para todos passa a valer somente a coluna de qualquer cartela e vice-versa.

- A partir daí, só vale a pontuação de cartela cheia.

- Os sorteios devem acontecer até algum jogador completar a cartela (BINGO!).

São 3 possibilidades de pontos:

Ao completar uma linha, o jogador recebe 1 ponto.

Ao completar uma coluna, o jogador recebe 1 ponto.

Ao completar a cartela, o jogador recebe 5 pontos.

Você vai precisar controlar o sorteio, onde não podem acontecer números repetidos, e também controlar as cartelas, onde cada cartela deve ter marcado os números sorteados para verificação do preenchimento da linha / coluna / cartela para contabilizar os pontos.

Ao final do jogo, deverá ser mostrado quem foram os jogadores vencedores e a pontuação de cada um.

Recursos opcionais:

Cada jogador pode ter mais de uma cartela.
O jogo deve ser capaz de ser jogado por mais de 2 jogadores, onde o usuário informa no inicio do programa a quantidade de jogadores que ele deseja.
 */
//Variaveis
int linhaColuna = 5;
int qtdJogadores = 0, qtdCartelas = 0;

//Vetor que tem os numeros a sortear: de 1 ao 99
int[] numerosASortear = new int[99];

//Matriz
int[,] cartela = new int[linhaColuna, linhaColuna];

//Criando os numeros para sorteio
for (int i = 0; i < numerosASortear.Length; i++)
{
    numerosASortear[i] = i + 1;
}
//Funcao que retornara a quantidade de cartelas para cada jogador
int PegarQuantidadeJogadores()
{
    Console.Write("Digite quantos jogadores o jogo terá: ");
    qtdJogadores = int.Parse(Console.ReadLine());

    return qtdJogadores;
}
//Funcao que retornara a quantidade de cartelas para cada jogador
int PegarQuantidadeCartelas()
{
    Console.Write("Digite quantas cartelas cada jogador terá: ");
    qtdCartelas = int.Parse(Console.ReadLine());

    return qtdCartelas;
}

void TratativaNumJogadorCartela()
{
    do
    {
        Console.WriteLine("Mínimo de 2 jogadores");
        PegarQuantidadeJogadores();
    } while (qtdJogadores < 2);

    do
    {
        Console.WriteLine("Mínimo de 1 cartela por jogador");
        PegarQuantidadeCartelas();
    } while (qtdCartelas < 1);
}
//Funcao para embaralhar o vetor
void EmbaralharVetor(int[] vetorParaEmbaralhar)
{
    Random rnd = new Random();

    for (int i = numerosASortear.Length - 1; i > 0; i--)
    {
        int indexAleatorio = rnd.Next(i + 1);
        int aleatorio1 = vetorParaEmbaralhar[i];
        int aleatorio2 = vetorParaEmbaralhar[indexAleatorio];
        vetorParaEmbaralhar[i] = aleatorio2;
        vetorParaEmbaralhar[indexAleatorio] = aleatorio1;
    }
}
//Funcao para criar cartela ja embaralhada
int[,] CriarCartela()
{
    Console.WriteLine();
    int count = 0;
    int[] vet_temp = new int[linhaColuna * linhaColuna];
    int[,] matriz = new int[linhaColuna, linhaColuna];
    vet_temp = numerosASortear;

    for (int i = 0; i < linhaColuna; i++)
    {
        for (int j = 0; j < linhaColuna; j++)
        {
            matriz[i, j] = vet_temp[count];
            count++;
        }
    }
    return matriz;
}

void ImprimirCartela(int[,] matriz, string mensagem)
{
    Console.WriteLine(mensagem);
    for (int i = 0; i < linhaColuna; i++)
    {
        Console.WriteLine();
        for (int j = 0; j < linhaColuna; j++)
        {
            Console.Write($" {matriz[i, j]:00} ");
        }
    }
}

Console.WriteLine("------------JOGO DO BINGO------------");
TratativaNumJogadorCartela();
EmbaralharVetor(numerosASortear);
cartela = CriarCartela();
ImprimirCartela(cartela, "Cartela 1");
EmbaralharVetor(numerosASortear);
cartela = CriarCartela();
ImprimirCartela(cartela, "\nCartela 2");
EmbaralharVetor(numerosASortear);
cartela = CriarCartela();
ImprimirCartela(cartela, "\nCartela 3");