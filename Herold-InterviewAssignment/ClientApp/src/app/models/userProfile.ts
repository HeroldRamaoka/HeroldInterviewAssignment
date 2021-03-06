export interface UserProfile {
    id: string,
    username: string;
    email: string;
    first_name: string;
    last_name: string;
    name: string;
    phone_number: string;
    age: string;
    birth_date: string;
    id_number: string;
    gender: string;
    physical_address: string;
    race: string;
    personal_email: string;
    tax_number: string;
    start_date: string;
    level: string;
    salary: string;
    next_review: string;
    days_to_birthday: string;
    leave_remaining: string;
    years_worked: string;
    employee_review: EmployeeReview[];
}

export interface EmployeeReview{
    date: string;
    id: any;
    salary: string;
    type: string;
}