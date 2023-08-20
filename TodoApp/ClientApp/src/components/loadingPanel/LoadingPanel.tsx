import React from 'react';
import { Backdrop, CircularProgress } from '@mui/material';
import { useLoading } from './LoadingContext';

const LoadingPanel: React.FC = () => {
  const { isLoading } = useLoading();

  return (
    <Backdrop open={isLoading} style={{ zIndex: 9999 }}>
      <CircularProgress color="inherit" />
    </Backdrop>
  );
};

export default LoadingPanel;
