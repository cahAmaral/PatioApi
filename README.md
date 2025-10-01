# Projeto PatioApi - Sistema de Controle de Pátio de Motos

## Integrantes
- RM558012  
- RM558301  
- RM556999  

## Descrição do Projeto
O **PatioApi** é uma API RESTful desenvolvida em .NET para controle de entrada, saída e movimentação de motos em pátios. O sistema permite rastrear a localização das motos, registrar operadores responsáveis e gerar dados para auditorias e dashboards.  

### Principais Funcionalidades
- Identificação de motos via **QR Code** ou **RFID/NFC**.  
- Identificação de operadores via crachá com QR Code ou login via app.  
- Controle de entrada e saída de motos.  
- Setorização automática dos pátios baseada em regras de tipo/modelo da moto, capacidade do setor e prioridade de uso/manutenção.  
- Histórico de movimentações das motos.  
- Dashboard visual com mapa do pátio mostrando setores e ocupação.  

---

## Arquitetura
- **Backend:** .NET Web API  
- **Banco de Dados:** Oracle  
- **Swagger/OpenAPI:** Documentação dos endpoints, exemplos de payload e modelos de dados.  
- **Entidades principais:**  
  - **Moto**: Representa cada moto do pátio.  
  - **Operador**: Usuário responsável pela movimentação.  
  - **Movimentacao**: Registro de entrada, saída e movimentação de motos.  

> A escolha da arquitetura se baseou em **boas práticas REST**, modularidade e facilidade de manutenção.  

---

## Endpoints Principais

### Moto
- `GET /api/motos` → Listar todas as motos  
- `GET /api/motos/{id}` → Obter moto por ID  
- `POST /api/motos` → Criar nova moto  
- `PUT /api/motos/{id}` → Atualizar moto existente  
- `DELETE /api/motos/{id}` → Excluir moto  

### Operador
- `GET /api/operadores` → Listar todos os operadores  
- `GET /api/operadores/{id}` → Obter operador por ID  
- `POST /api/operadores` → Criar novo operador  
- `PUT /api/operadores/{id}` → Atualizar operador existente  
- `DELETE /api/operadores/{id}` → Excluir operador  

### Movimentacao
- `GET /api/movimentacoes` → Listar todas as movimentações  
- `GET /api/movimentacoes/{id}` → Obter movimentação por ID  
- `POST /api/movimentacoes` → Criar nova movimentação  
- `PUT /api/movimentacoes/{id}` → Atualizar movimentação existente  
- `DELETE /api/movimentacoes/{id}` → Excluir movimentação  

---

## Exemplos de uso

### Criar Moto
```http
POST /api/motos
Content-Type: application/json

{
  "placa": "ABC1A28",
  "status": "Ativa",
  "idModelo": 1
}
```

### Listar Motos
```http
GET /api/motos
```

### Criar Operador
```http
POST /api/operadores
Content-Type: application/json

{
  "nome": "Lucas",
  "cargo": "Assistente",
  "idPatio": 1
}
```

---

## Executando a API

1. Clonar o repositório:

```bash
git clone https://github.com/cahAmaral/PatioApi.git
cd patioapi
```

2. Restaurar pacotes NuGet:

```bash
dotnet restore
```

3. Atualizar a string de conexão no `appsettings.json`:

```json
"ConnectionStrings": {
  "OracleConnection": "User Id=rm558012;Password=200106;Data Source=oracle.fiap.com.br:1521/ORCL;"
}
```

4. Rodar a API:

```bash
dotnet run
```

5. Acessar documentação Swagger:

```
http://localhost:5204/swagger
```

---
