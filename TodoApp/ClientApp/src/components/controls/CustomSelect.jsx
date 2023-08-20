import React from 'react';
import { FormControl, InputLabel, Select, MenuItem } from '@mui/material';

interface Option {
  id: number;
  value: string;
}

interface CustomSelectProps {
  options: Option[];
  onSelect: (selectedValue: number) => void;
  labelName: string;
}

function CustomSelect({ options, onSelect, labelName }: CustomSelectProps) {

  const handleSelectChange = (event: React.ChangeEvent<{ value: unknown }>) => {
    debugger;
    const selectedValue = Number(event.target.value);
    if (!isNaN(selectedValue)) {
      onSelect(selectedValue);
    }
  };

  return (
    <FormControl variant="outlined" fullWidth size="small">
      <InputLabel id="select-label">{labelName}</InputLabel>
      <Select
        labelId="select-label"
        id="select"
        onChange={handleSelectChange}
        label={labelName}
      >
        {options.map((option) => (
          <MenuItem key={option.id} value={option.id}>
            {option.value}
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
}

export default CustomSelect;
