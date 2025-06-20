SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';
SELECT 
    COLUMN_NAME, 
    CONSTRAINT_NAME, 
    TABLE_NAME 
FROM 
    INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE 
    CONSTRAINT_NAME LIKE 'PK_%';
    SELECT 
    fk.name AS FK_constraint_name,
    tp.name AS parent_table,
    ref.name AS referenced_table
FROM 
    sys.foreign_keys AS fk
    INNER JOIN sys.tables AS tp ON fk.parent_object_id = tp.object_id
    INNER JOIN sys.tables AS ref ON fk.referenced_object_id = ref.object_id;
