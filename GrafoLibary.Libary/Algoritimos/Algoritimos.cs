using GrafoLibary.Libary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLibary.Libary.Algoritimos
{
    public class Algoritimos
    {
        /// <summary>
        /// Método para calcular a distancia de uma rota no grafo
        /// </summary>
        /// <param name="grafo">Grafo no qual será calculado a rota</param>
        /// <param name="rota">rota a ser calculada</param>
        /// <returns>Resposta, contém um titulo e o custo da rota</returns>
        public Resposta CalculaDistancia(Grafo grafo, List<Vertice> rota)
        {
            if (grafo.Peso)
            {
                Resposta resposta = new Resposta();
                string linhaResp = "DISTANCIA:";
                foreach (var vertice in rota)
                {
                    linhaResp += " " + vertice.Nome;
                }
                resposta.Titulo = linhaResp;


                Double resultado = 0.0;
                Aresta aresta;

                for (int i = 0; i < rota.Count; i++)
                {
                    if (i != rota.Count - 1)
                    {
                        aresta = rota[i].ArestasSaindo.FirstOrDefault(x => x.VerticeDestino == rota[i + 1]);
                        if (aresta != null)
                        {
                            resultado += aresta.Peso;
                        }
                    }
                }

                resposta.Linhas.Add(new Linha { TextoLinha = resultado.ToString() });
                return resposta;
            }
            return null;
        }

        /// <summary>
        /// Método para fazer busca em profundidade no grafo
        /// </summary>
        /// <param name="grafo">Grafo no qual sera feito a busca</param>
        /// <param name="vOrigem">vertice de origem</param>
        /// <param name="vDestino">vertice a ser encontrado no grafo</param>
        /// <returns>Resposta, contém um tirulo e o caminho percorrido no grafo até encontrar o destino</returns>
        public Resposta BuscaEmProfundidade(Grafo grafo, Vertice vOrigem, Vertice vDestino)
        {
            List<Vertice> visitados = new List<Vertice>();
            Stack<Vertice> fronteira = new Stack<Vertice>();
            Vertice vAtual = grafo.Vertices.First(x => x.Nome == vOrigem.Nome);
            Resposta resposta = new Resposta();
            Linha linhaResposta;
            string linha;

            try
            {
                if (vAtual != null)
                {
                    resposta.Titulo = String.Format("PROFUNDIDADE {0} {1}:", vOrigem.Nome, vDestino.Nome);
                    linhaResposta = new Linha { TextoLinha = vAtual.Nome };
                    resposta.Linhas.Add(linhaResposta);
                    while (true)
                    {
                        if (!(vAtual == vDestino))
                        {
                            foreach (var aresta in vAtual.ArestasSaindo.OrderByDescending(x => x.VerticeDestino.Nome))
                            {
                                fronteira.Push(aresta.VerticeDestino);
                            }

                            visitados.Add(vAtual);

                            //pega o proximo vertice não visitado na fronteira
                            for (int i = 0; i < fronteira.Count - 1; i++)
                            {
                                vAtual = fronteira.Peek();
                                if (visitados.Contains(vAtual))
                                {
                                    vAtual = fronteira.Pop();
                                    continue;
                                }
                                break;
                            }

                            linha = "";
                            foreach (var vertice in fronteira)
                            {
                                if (!visitados.Contains(vertice))
                                {
                                    linha += " " + vertice.Nome;
                                }
                            }
                            if (!string.IsNullOrEmpty(linha))
                            {
                                resposta.Linhas.Add(new Linha { TextoLinha = linha });
                            }
                        }
                        else
                        {
                            return resposta;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método para fazer a busca em largura
        /// </summary>
        /// <param name="grafo">Grafo no qual será feito a busca</param>
        /// <param name="vAtual">vertice de onde se inicia a busca</param>
        /// <param name="vDestino">vertice a ser encontrado no grafo</param>
        /// <returns>Resposta, contem um titulo e o caminho percorrido até encontrar o vertice</returns>
        public Resposta BuscaEmLargura(Grafo grafo, Vertice vOrigem, Vertice vDestino)
        {
            List<Vertice> fronteira = new List<Vertice>();
            List<Vertice> visitados = new List<Vertice>();
            Vertice vAtual = grafo.Vertices.First(x => x.Nome == vOrigem.Nome);
            Resposta resposta = new Resposta();
            Linha linhaResposta;
            string linha;

            try
            {
                resposta.Titulo = String.Format("LARGURA {0} {1}:", vOrigem.Nome, vDestino.Nome);
                linhaResposta = new Linha { TextoLinha = vAtual.Nome };
                resposta.Linhas.Add(linhaResposta);

                while (true)
                {
                    if (vAtual != null)
                    {
                        if (!(vAtual == vDestino))
                        {
                            //adiciona todos os destinos do vertice atual a fronteira
                            foreach (var aresta in vAtual.ArestasSaindo.OrderBy(x => x.VerticeDestino.Nome))
                            {
                                fronteira.Add(aresta.VerticeDestino);
                            }
                            //adiciona o vertice atual a lista de visitados
                            visitados.Add(vAtual);

                            //pega o proximo vertice não visitado na fronteira
                            for (int i = 0; i < fronteira.Count - 1; i++)
                            {
                                if (!visitados.Contains(fronteira[i]))
                                {
                                    vAtual = fronteira[i];
                                    break;
                                }
                                fronteira.Remove(fronteira[i]);
                            }

                            linha = "";
                            foreach (var vertice in fronteira)
                            {
                                if (!visitados.Contains(vertice))
                                {
                                    linha += " " + vertice.Nome;
                                }
                            }
                            resposta.Linhas.Add(new Linha { TextoLinha = linha });
                        }
                        else
                        {
                            return resposta;
                        }

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                //Erro ao executar o algoritimo
                throw;
            }
        }

        /// <summary>
        /// Metodo para calcular o menor caminho de um vertice a outro
        /// </summary>
        /// <param name="grafo">Grafo ao qual sera feito a busca</param>
        /// <param name="vOrigem">Vertice de onde se inicia o calculo</param>
        /// <param name="vDestino">vertice de destino</param>
        /// <returns>Resposta, contém um titulo, o caminho percorrido no grafo e o custo da rota</returns>
        public Resposta MenorCaminho(Grafo grafo, Vertice vOrigem, Vertice vDestino)
        {
            List<Vertice> naoVisitados;
            Dictionary<Vertice, double> distancias = new Dictionary<Vertice, double>();
            var anteriores = new Dictionary<string, string>();
            Vertice vAtual = vOrigem;

            foreach (var vertice in grafo.Vertices)
            {
                if (vertice == vOrigem)
                {
                    distancias.Add(vertice, 0.0);
                }
                else
                {
                    distancias.Add(vertice, double.MaxValue);
                }
            }

            naoVisitados = grafo.Vertices;

            do
            {
                double pesoVerticeAtual = distancias[vAtual];
                foreach (var aresta in vAtual.ArestasSaindo)
                {
                    double pesoAresta = distancias[aresta.VerticeDestino];
                    double pesoTotal = pesoVerticeAtual + aresta.Peso;
                    if (pesoTotal < pesoAresta)
                    {
                        distancias[aresta.VerticeDestino] = pesoTotal;
                        if (anteriores.ContainsKey(aresta.VerticeDestino.Nome))
                        {
                            anteriores[aresta.VerticeDestino.Nome] = vAtual.Nome;
                        }
                        else
                        {
                            anteriores.Add(aresta.VerticeDestino.Nome, vAtual.Nome);
                        }
                    }
                }
                List<Aresta> lsAresta = vAtual.ArestasSaindo;
                naoVisitados.Remove(vAtual);
                double menorValor = double.MaxValue;
                foreach (var aresta in lsAresta)
                {
                    if (aresta.Peso < menorValor && naoVisitados.Contains(aresta.VerticeDestino))
                    {
                        menorValor = aresta.Peso;
                        vAtual = aresta.VerticeDestino;
                    }
                }
            } while (naoVisitados.Count > 0);

            Resposta resposta = new Resposta();
            string linha = "";
            resposta.Linhas.Add(new Linha { TextoLinha = string.Format("MENOR CAMINHO {0} {1}", vOrigem.Nome, vDestino.Nome) });

            string anterior = vDestino.Nome;
            linha += " " + anterior;
            do
            {
                anterior = anteriores[anterior];
                linha += " " + anterior;
            } while (!anterior.Equals(vOrigem.Nome));
            resposta.Linhas.Add(new Linha { TextoLinha = InverterString(linha) });
            resposta.Linhas.Add(new Linha { TextoLinha = distancias[vDestino].ToString() });

            return resposta;
        }

        /// <summary>
        /// Método para montar o grafo
        /// </summary>
        /// <param name="caminhoArquivo">Caminho do arquivo</param>
        /// <returns>Um grafo preenchido de acordo com o arquivo</returns>
        public static Grafo MontaGrafo(string caminhoArquivo)
        {
            Grafo grafo = new Grafo();
            int indice = 0;
            string[] linhas = System.IO.File.ReadAllLines(caminhoArquivo);

            string linha = linhas[1];
            linha = linha.Remove(linha.Length - 1).Replace(" ", ",");
            string[] linhaSplit = linha.Split(',');

            //adiciona todos os vertices ao grafo
            foreach (var item in linhaSplit)
            {
                grafo.Vertices.Add(new Vertice { Nome = item });
            }

            linha = linhas[2].Remove(linhas[2].Length - 1).Trim();
            grafo.Direcionado = linha.Equals("true");

            linha = linhas[3].Remove(linhas[3].Length - 1).Trim();
            grafo.Peso = linha.Equals("true");

            for (int i = 6; i < linhas.Length; i++)
            {
                if (String.IsNullOrEmpty(linhas[i]))
                {
                    indice = i;
                    break;
                }

                linhaSplit = linhas[i].Replace(",", "").Replace(";", "").Replace(" ", ",").Split(',');
                //adiciona todas as arestas ao grafo
                grafo.Arestas.Add(new Aresta
                {
                    VerticeOrigem = grafo.Vertices.First(x => x.Nome == linhaSplit[0]),
                    VerticeDestino = grafo.Vertices.First(x => x.Nome == linhaSplit[1]),
                    Peso = Convert.ToDouble(linhaSplit[2])
                });
            }

            //adiciona as arestas saindo e chegando para cada vertice do grafo
            foreach (var aresta in grafo.Arestas)
            {
                foreach (var vertice in grafo.Vertices)
                {
                    if (aresta.VerticeOrigem == vertice)
                    {
                        vertice.ArestasSaindo.Add(aresta);
                    }
                    else if (aresta.VerticeDestino == vertice)
                    {
                        vertice.ArestasChegando.Add(aresta);
                    }
                }
            }

            List<Vertice> lsVerticesComando;
            Vertice verticeComando;
            for (int i = indice; i < linhas.Length; i++)
            {
                if (!string.IsNullOrEmpty(linhas[i]) && !linhas[i].Equals("COMANDOS"))
                {
                    string[] linhaComando = linhas[i].Replace(";", "").Replace(" ", ",").Split(',');
                    string nomeComando = linhaComando[0];
                    lsVerticesComando = new List<Vertice>();
                    for (int j = 1; j < linhaComando.Length; j++)
                    {
                        verticeComando = grafo.Vertices.First(x => x.Nome == linhaComando[j]);
                        lsVerticesComando.Add(verticeComando);
                    }
                    grafo.Comandos.Add(new Comando { Nome = nomeComando, Vertices = lsVerticesComando });
                }
            }

            return grafo;
        }

        /// <summary>
        /// Método que executa todos os comandos contidos no arquivo
        /// </summary>
        /// <param name="caminhoArquivo">caminho do arquivo</param>
        /// <returns>lista de resposta, contem a resposta de todos os comandos executados</returns>
        public static List<Resposta> ExecutaComandos(string caminhoArquivo)
        {
            try
            {
                Grafo grafo = Algoritimos.MontaGrafo(caminhoArquivo);
                Algoritimos alg = new Algoritimos();
                List<Resposta> respostas = new List<Resposta>();
                foreach (var comando in grafo.Comandos)
                {
                    if (comando.Nome.Equals("DISTANCIA"))
                    {
                        respostas.Add(alg.CalculaDistancia(grafo, comando.Vertices));
                    }
                    else if (comando.Nome.Equals("LARGURA"))
                    {
                        respostas.Add(alg.BuscaEmLargura(grafo, comando.Vertices[0], comando.Vertices[1]));
                    }
                    else if (comando.Nome.Equals("PROFUNDIDADE"))
                    {
                        respostas.Add(alg.BuscaEmProfundidade(grafo, comando.Vertices[0], comando.Vertices[1]));
                    }
                    else if (comando.Nome.Equals("MENORCAMINHO"))
                    {
                        respostas.Add(alg.MenorCaminho(grafo, comando.Vertices[0], comando.Vertices[1]));
                    }
                }
                return respostas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para inverter uma striing
        /// </summary>
        /// <param name="Texto">string a ser invertida</param>
        /// <returns>string invertida</returns>
        private string InverterString(string Texto)
        {
            //Cria a partir do texto original um array de char
            char[] ArrayChar = Texto.ToCharArray();

            //Com o array criado invertemos a ordem do mesmo
            Array.Reverse(ArrayChar);

            //Agora basta criarmos uma nova String, já com o array invertido.
            return new string(ArrayChar);
        }
    }
}
