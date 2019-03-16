DECLARE @json NVARCHAR(MAX)
DECLARE @champions TABLE
(
	champion_name varchar(50),
	json_value varchar(MAX)
)

SELECT @json = BulkColumn
FROM OPENROWSET (BULK 'C:\Users\Johnny Pao\Desktop\Work and Personal\LeagueOfLegends\DataDragonStatic\9.5.1\data\en_US\championFull.json', SINGLE_CLOB) as j

SET @json = (SELECT [value] FROM OPENJSON(@json) WHERE [key] = 'data')

INSERT INTO @champions
SELECT [key], [value]
FROM OPENJSON(@json)

INSERT INTO Champions
SELECT 
champion_name,
(SELECT [value] 
 FROM OPENJSON((SELECT json_value 
				FROM @champions AS TABLE2 
				WHERE TABLE2.champion_name = TABLE1.champion_name))
 WHERE [key] = 'key') AS id,
(SELECT [value] 
 FROM OPENJSON((SELECT json_value 
				FROM @champions AS TABLE2 
				WHERE TABLE2.champion_name = TABLE1.champion_name))
 WHERE [key] = 'title') AS title,
(SELECT [value] 
 FROM OPENJSON((SELECT [value] 
			    FROM OPENJSON((SELECT json_value 
							   FROM @champions AS TABLE2 
							   WHERE TABLE2.champion_name = TABLE1.champion_name))
				WHERE [key] = 'image'))
 WHERE [key] = 'full') AS image
FROM @champions AS TABLE1;