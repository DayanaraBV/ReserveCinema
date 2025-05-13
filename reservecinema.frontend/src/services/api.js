import axios from 'axios';

const API_BASE_URL = 'http://localhost:5207/api'; 

export const getShows = async () => {
  const response = await axios.get(`${API_BASE_URL}/show`);
  return response.data;
};

export const getAvailableSeats = async (showId) => {
  const response = await axios.get(`${API_BASE_URL}/reservation/seats/${showId}`);
  return response.data;
};

export const createReservation = async (data) => {
  const response = await axios.post(`${API_BASE_URL}/reservation`, data);
  return response.data;
};