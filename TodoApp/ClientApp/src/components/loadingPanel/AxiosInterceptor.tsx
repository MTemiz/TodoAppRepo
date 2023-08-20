import React from 'react';
import axios from 'axios';
import { useLoading } from './LoadingContext';

const AxiosInterceptor: React.FC = () => {
  const { setLoading } = useLoading();

  axios.interceptors.request.use(
    (config) => {
      setLoading(true);
      return config;
    },
    (error) => {
      setLoading(false);
      return Promise.reject(error);
    }
  );

  axios.interceptors.response.use(
    (response) => {
      setLoading(false);
      return response;
    },
    (error) => {
      setLoading(false);
      return Promise.reject(error);
    }
  );

  return null;
};

export default AxiosInterceptor;
