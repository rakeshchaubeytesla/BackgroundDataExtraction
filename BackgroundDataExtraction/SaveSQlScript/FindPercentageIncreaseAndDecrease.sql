Select 
db1.SYMBOL,
db1.[CLOSE],
db1.GeneratedDate,
db2.[CLOSE],
db2.GeneratedDate,
db2.PREVCLOSE/ db1.PREVCLOSE * 100 percinc

From DailyBhavTemp db1
join DailyBhavTemp db2 on db1.SYMBOL = db2.SYMBOL
WHERE 
--db1.SYMBOL = 'INFY' AND
db1.GeneratedDate= (select min(GeneratedDate) from DailyBhav where DailyBhav.Symbol = db1.SYMBOL)
and db2.GeneratedDate = (select max(GeneratedDate) from DailyBhav where DailyBhav.SYMBOL = DailyBhav.SYMBOL) and db1.SERIES ='EQ'  and db2.SERIES ='EQ'
order by percinc desc




