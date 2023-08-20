import React, { useState } from 'react';
import { Dialog, DialogActions, DialogContent, Button } from '@mui/material';

const DeleteConfirmationDialog = ({ open, onClose, onConfirm }) => {
    return (
      <Dialog open={open} onClose={onClose}>
        <DialogContent>
          Silme işlemini onaylıyor musunuz?
        </DialogContent>
        <DialogActions>
          <Button onClick={onClose} color="primary">
            Hayır
          </Button>
          <Button onClick={onConfirm} color="secondary">
            Evet
          </Button>
        </DialogActions>
      </Dialog>
    );
  };
  
  export default DeleteConfirmationDialog;