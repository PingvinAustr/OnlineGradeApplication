import axios from 'axios';

export const loginUser = async (username: string, password: string) => {
    try {
        const response = await axios.post(`https://localhost:7264/loginUser?username=${username}&password=${password}`);
        return response.data;
    } catch (error) {
        console.error('Error logging in user:', error);
        throw error;
    }
}

export const getUserRole = async (userId:number) => {
    try {
        const response = await axios.get(`https://localhost:7264/api/Person/GetPersonRoleById?userId=${userId}`);
        return response.data;
    } catch (error) {
        throw error;
    }
}

export const getUserDataById = async (userId: number | null) =>{
    try {
        const response = await axios.get(`https://localhost:7264/api/Person/${userId}`);
        return response.data;
    } catch (error) {
        throw error;
    }
}