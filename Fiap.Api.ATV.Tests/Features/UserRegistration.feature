Feature: Cadastro de Usuário
  Scenario: Usuário se cadastra com sucesso
    Given que eu tenha os dados de um novo usuário
    When eu envio uma requisição POST para "/api/users"
    Then o sistema deve retornar status code 201
    And o corpo da resposta deve conter o ID do novo usuário
    And o corpo da resposta deve seguir o esquema JSON de usuário válido
