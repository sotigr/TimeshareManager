create table Clients(
id	COUNTER PRIMARY KEY,
UserNumber Text,
BankNumber Text,
RCINumber Text, 
cCompany Text,
cNotes Memo
);
create table Emails(
id COUNTER PRIMARY KEY,
client_id Integer,
email Text
);
create table Names(
id COUNTER PRIMARY KEY,
client_id Integer,
name Text
);
create table Contracts(
id COUNTER PRIMARY KEY,
client_id Integer,
ContractName Text
);
create table Phones(
id	COUNTER PRIMARY KEY,
client_id	Integer,
pNumber Text 
);
create table Addresses(
id	COUNTER PRIMARY KEY,
client_id	Integer,
uAddress Text 
);
create table Appartments(
id	COUNTER PRIMARY KEY,
client_id	Integer,
AppartmentNumber Text,
aWeek Text
);
create table Debts(
id COUNTER PRIMARY KEY,
client_id Integer,
appartment_id Integer,
mvalue money
);
create table Payoffs(
id COUNTER PRIMARY KEY,
client_id Integer,
appartment_id Integer,
mvalue money,
pof Text
);
