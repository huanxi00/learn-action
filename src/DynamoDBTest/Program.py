import boto3

# 创建 DynamoDB Local 客户端
dynamodb = boto3.client(
    "dynamodb",
    endpoint_url="http://localhost:8000",  # 指定 DynamoDB Local 的端点
    region_name="us-west-1",  # 可以设置为任何值
    aws_access_key_id="None",  # 在本地测试时不需要提供真实的 AWS 访问密钥
    aws_secret_access_key="None",
)  # 在本地测试时不需要提供真实的 AWS 秘密密钥

# 示例：创建一个 DynamoDB 表
table_name = "MyTestTable"
key_schema = [{"AttributeName": "id", "KeyType": "HASH"}]  # 主键
attribute_definitions = [{"AttributeName": "id", "AttributeType": "N"}]
provisioned_throughput = {"ReadCapacityUnits": 5, "WriteCapacityUnits": 5}

dynamodb.create_table(
    TableName=table_name,
    KeySchema=key_schema,
    AttributeDefinitions=attribute_definitions,
    ProvisionedThroughput=provisioned_throughput,
)

# 示例：向表中插入数据
response = dynamodb.put_item(
    TableName=table_name, Item={"id": {"N": "1"}, "name": {"S": "John Doe"}}
)

print("PutItem succeeded:", response)

# 示例：查询表中数据
response = dynamodb.get_item(TableName=table_name, Key={"id": {"N": "1"}})

item = response.get("Item")
if item:
    print("GetItem succeeded:", item)
else:
    print("Item not found")

# 示例：删除表
dynamodb.delete_table(TableName=table_name)
