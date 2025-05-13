import axios from 'axios';

const API_BASE_URL = 'http://localhost:5207/api'; 

export const getShows = async () => {
  const response = await axios.get(`${API_BASE_URL}/show`);
  return response.data;
};