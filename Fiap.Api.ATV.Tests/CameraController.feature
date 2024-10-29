Feature: Consultar Câmeras
  Como um usuário do sistema
  Quero verificar se as APIs de câmeras retornam as informações corretas
  Para garantir a disponibilidade e integridade dos dados

  Scenario: Obter lista de câmeras com sucesso
    Given a API está disponível
    When o usuário requisita a lista de câmeras
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter uma lista de câmeras

  Scenario: Obter câmera específica com sucesso
    Given a API está disponível
    And a câmera com ID 1 existe
    When o usuário requisita a câmera com ID 1
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter as informações da câmera com ID 1

  Scenario: Erro ao requisitar uma câmera inexistente
    Given a API está disponível
    And a câmera com ID 9999 não existe
    When o usuário requisita a câmera com ID 9999
    Then o status da resposta deve ser 404
    And o corpo da resposta deve conter uma mensagem de erro
