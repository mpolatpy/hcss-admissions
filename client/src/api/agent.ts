import axios, { AxiosError, AxiosResponse } from 'axios';
import { Application } from '../models/ApplicationFormModels';
import { SchoolYear } from '../models/SchoolYear';


export const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const SchoolYears = {
    list: () => requests.get<SchoolYear[]>('/schoolYears'),
    detail: (name: string) => requests.get<SchoolYear>(`/schoolYears/${name}`),
}

const Applications = {
    list: () => requests.get<SchoolYear[]>('/applications'),
    detail: (id: string) => requests.get<SchoolYear>(`/applications/${id}`),
    create: (application: Application) => requests.post('applications/new', application)
}

const agent = {
    SchoolYears,
    Applications
}

export default agent;