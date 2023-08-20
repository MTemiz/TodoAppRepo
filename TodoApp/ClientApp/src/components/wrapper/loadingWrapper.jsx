import React from 'react';
import { Backdrop, CircularProgress } from '@mui/material';

const LoadingWrapper = ({ isLoading, children }) => {
  return (
    <div>
      {isLoading && (
        <Backdrop open={isLoading}>
          <CircularProgress color="inherit" />
        </Backdrop>
      )}
      {children}
    </div>
  );
};

export default LoadingWrapper;
