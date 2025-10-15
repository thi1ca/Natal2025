--Relatorios

-- Relatorio clientes que rasparam
select r.*, l.*, cu.cup_cupom_data, c.* from Raspados r 
left join calendario  c on r.cal_id = c.cal_id 
inner join cliente cl on r.cli_id = cl.cli_id 
left join cupom cu on r.cup_id = cu.cup_id
inner join loja l on cu.loj_id = l.loj_id
where ras_data >= '2024-05-01'
order by 1 desc

select * from cliente where cast(cli_data as date) = '2024-05-22'

  select cu.loj_id, loj_nome, r.ras_data, c.cal_data_premio, p.pre_nome ,cli_nome, cli_cpf, cli_email, cup_cupom_data ,r.*, cl.*, c.*  from Raspados r 
left join calendario  c on r.cal_id = c.cal_id 
inner join cliente cl on r.cli_id = cl.cli_id 
left join cupom cu on r.cup_id = cu.cup_id
left join premio p on c.pre_id = p.pre_id
inner join loja l on cu.loj_id = l.loj_id
where --ras_data >= '2024-05-01' and
r.cal_id is not null and cu.pdv is not null --and cal_voucher =''
order by 3 asc


-- Relatorio de Total raspados por loja
select cu.loj_id, loj_nome, count(*) Total --cup_cupom_data 
from Raspados r 
left join calendario  c on r.cal_id = c.cal_id 
inner join cliente cl on r.cli_id = cl.cli_id 
inner join cupom cu on r.cup_id = cu.cup_id
inner join loja l on cu.loj_id = l.loj_id
where  ras_data >= '2024-05-01'
group by cu.loj_id, loj_nome
order by 3 desc

-- Relatorio de Total raspados por loja com data do cupom
select cu.loj_id, loj_nome, count(*) Total, CAST(CAST(cup_cupom_data AS DATE) AS DATETIME) AS cup_cupom_data
from Raspados r 
left join calendario  c on r.cal_id = c.cal_id 
inner join cliente cl on r.cli_id = cl.cli_id 
inner join cupom cu on r.cup_id = cu.cup_id
inner join loja l on cu.loj_id = l.loj_id
group by cu.loj_id, loj_nome,  CAST(CAST(cup_cupom_data AS DATE) AS DATETIME)
order by 3 desc, 4 desc

-- Relatorio de Total raspados por loja com data raspada pelo cliente
select cu.loj_id, loj_nome, count(*) Total, CAST(CAST(ras_data AS DATE) AS DATETIME) AS ras_data
from Raspados r 
left join calendario  c on r.cal_id = c.cal_id 
inner join cliente cl on r.cli_id = cl.cli_id 
inner join cupom cu on r.cup_id = cu.cup_id
inner join loja l on cu.loj_id = l.loj_id
group by cu.loj_id, loj_nome,  CAST(CAST(ras_data AS DATE) AS DATETIME)
order by 4 desc, 3 desc



---------------------------------------------
--Ver qual está funfando

--113 clientes cadastraram hoje
--50 eram da penha
--43 eram de cupons de hoje
--Total de cupons hoje da penha 372
--Conversão 11,56%

--Lista Cadastro de clientes por data de cadastro, limitado a loja 33 cuja compra foi feita no dia especifico
select cli.*, loj_nome, c.* from Cupom C 
inner join loja l on c.loj_id = l.loj_id
INNER JOIN (
  SELECT cup_cpf, MAX(cup_cupom_data) AS MaxDate
  FROM Cupom
  GROUP BY cup_cpf
) CD ON C.cup_cpf = CD.cup_cpf AND C.cup_cupom_data = CD.MaxDate
inner join cliente cli on cli.cli_cpf = cd.cup_cpf
 where cli_data >= '2024-05-02' and cli_data <= '2024-05-03' and c.loj_id = 33 and cup_cupom_data >= '2024-05-02' and cup_cupom_data <='2024-05-03'
order by 1 desc




select cli.*, loj_nome, c.* from Cupom C 
INNER JOIN (
  SELECT cup_cpf, MAX(cup_cupom_data) AS MaxDate
  FROM Cupom
  GROUP BY cup_cpf
) CD ON C.cup_cpf = CD.cup_cpf AND C.cup_cupom_data = CD.MaxDate
inner join cliente cli on cli.cli_cpf = cd.cup_cpf
inner join loja l on c.loj_id = l.loj_id
 where cli_data >= '2024-05-02' and c.loj_id = 33 and cup_cupom_data >= '2024-05-02' and cup_cupom_data <='2024-05-03'
--order by 3 asc
order by 1 desc

-------------------------------------------------------------------
--END


--Caixas que mais tiveram cliente cadastrando
select NomeOperador, count(nomeOperador) total from (
select cli.cli_nome, loj_nome, c.* from Cupom C 
inner join loja l on c.loj_id = l.loj_id
INNER JOIN (
  SELECT cup_cpf, MAX(cup_cupom_data) AS MaxDate
  FROM Cupom
  GROUP BY cup_cpf
) CD ON C.cup_cpf = CD.cup_cpf AND C.cup_cupom_data = CD.MaxDate
inner join cliente cli on cli.cli_cpf = cd.cup_cpf
 where cli_data >= '2024-05-02' and cli_data <= '2024-05-03' and c.loj_id = 33 and cup_cupom_data >= '2024-05-02' and cup_cupom_data <='2024-05-03'
) operador
group by nomeOperador order by 2 desc

--CPFs com mais transações e cruzando com cpf de funcionarios
  select v.cpf, count(v.cpf) total, f.nome as 'NomeFuncionario', NomeLoja, v.nome 
  from TTV_DADOS_VENDA_CPF v left join ttv_funcionario f on v.cpf = f.cpf
  where codLoja < 2000
  group by v.cpf, f.nome , nomeLoja, v.nome
  having count(v.cpf) > 10
  order by count(v.cpf) desc

  --CPFs com mais transações e cruzando com cpf de funcionarios ativos em 2024
  select v.cpf, count(v.cpf) total, f.nome as 'NomeFuncionario', NomeLoja, v.nome 
  from TTV_DADOS_VENDA_CPF v left join ttv_funcionario f on v.cpf = f.cpf
  where codLoja < 2000 and Year(v.data) = 2024 and f.nome = v.nome and data_rescisao_rh is not null
  group by v.cpf, f.nome , nomeLoja, v.nome
  --having count(v.cpf) > 10
  order by count(v.cpf) desc

--CPFs com mais transacoes
    select v.cpf, count(v.cpf) total
  from TTV_DADOS_VENDA_CPF v 
  group by v.cpf
  having count(v.cpf) > 5
  order by count(v.cpf) desc


  --QUERY PARA LIMPEZA DE DADOS
  --LIMPE PELOS QUE GANHARAM E NÂO FAZ SENTIDO

  select r.ras_data, c.cal_data_premio, p.pre_nome ,cli_nome, cli_cpf, cli_email ,r.*, cl.*, c.*  from Raspados r 
left join calendario  c on r.cal_id = c.cal_id 
inner join cliente cl on r.cli_id = cl.cli_id 
left join cupom cu on r.cup_id = cu.cup_id
left join premio p on c.pre_id = p.pre_id
where --ras_data >= '2024-05-01' and
r.cal_id is not null and cu.pdv is null and cal_voucher =''
order by 1 desc


select * from calendario where cal_id = 23

select * from cliente where cli_id = 18

--delete from raspados where cal_id = 41 and ras_id =  285
--delete from calendario where cal_id = 41 
--delete from cupom where cli_id = 131 and cup_cpf = '31226428835' and cup_id <> 496


  --CPFs com mais transações e cruzando com cpf de funcionarios
  select v.cpf, count(v.cpf) total, f.nome, NomeLoja, v.nome 
  from TTV_DADOS_VENDA_CPF v left join ttv_funcionario f on v.cpf = f.cpf
  where codLoja < 2000
  group by v.cpf, f.nome , nomeLoja, v.nome
  having count(v.cpf) > 10
  order by count(v.cpf) desc

--CPFs com mais transacoes
    select v.cpf, count(v.cpf) total
  from TTV_DADOS_VENDA_CPF v 
  group by v.cpf
  having count(v.cpf) > 5
  order by count(v.cpf) desc

  select v.cpf, count(v.cpf) total
  from ttv_funcionario v
  group by v.cpf
  having count(v.cpf) > 1
  order by count(v.cpf) desc