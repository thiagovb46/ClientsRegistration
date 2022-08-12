# Documentação: Registro de Clientes com seus Endereços e Telefones
Registro de Clientes e Endereços com validação na API dos Correios.
# Arquitetura do Projeto 
A arquitetura do projeto segue padrões, como: 
- Casos de uso separados em arquivos diferentes no projeto Application, respeitando o princípio de responsabilidade única
- Utilização de Data Transfer Objects para não expor as entidades do banco de dados 
- Inversão e Injeção de Dependência para melhor organização do código e em respeito ao princípio de Inversão de controle, preferindo a utlização de contratos em vez de intâncias diretas.
## Projetos da Solução
- ClientsRegistration.Model : Definição das entidades e contratos de repositórios
- ClientsRegistration.Infra : Classes de  contexto, implementação de repositórios e demais infraestruturas 
- ClientsRegistration.Application : Regras de negócio, manipulação de dados e camada de interação entre a API e os repositórios
- ClientsRegistration.Api : Api que expões os end-points para consumo dos recursos implementados.
- ClientsRegistration.Test : Projeto com testes unitários dos casos de uso.

# Execução
- O projeto foi desenvolvido utilizando o ORM Entity Framework Core com banco de dados  SQLServer localDb, para executá-lo, primeiro é necessário aplicar as migrações no banco de dados,  por meio do comando "update-database" no ConsoleManager do Visual Studio, lembre-se de selecionar o ClientsRegistration.Api como projeto default, logo em seguida inicie o projeto ClientsRegistration.Api.

# Testes Unitários
- Foram criados métodos unitários para verificar o correto funcionamento dos métodos responsáveis por cada caso de uso da api.
