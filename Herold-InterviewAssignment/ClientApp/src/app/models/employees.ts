export interface Employees {
    id: string,
    username: string;
    email: string;
    first_name: string;
    last_name: string;
    name: string;
    phone_number: string;
    position: Position;
    birth_date: string;
}

export interface Position{
    id: any;
    level: string;
    name: string;
}