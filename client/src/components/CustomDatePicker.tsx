import React, { useEffect, useState } from 'react';
import { useField } from 'formik';
import TextField from '@mui/material/TextField';
import DateAdapter from '@mui/lab/AdapterMoment';
import LocalizationProvider from '@mui/lab/LocalizationProvider';
import DatePicker from '@mui/lab/DatePicker';
import FormControl from '@mui/material/FormControl';
import FormHelperText from '@mui/material/FormHelperText';

interface Props {
  label: string;
  name: string;
  variant?: "standard" | "filled" | "outlined" | undefined;
}

export default function CustomDatePicker(props: Props) {
  const { name, variant } = props;
  const [field, meta, helper] = useField(name);
  const { setValue } = helper;
  const { value } = field;
  const [selectedDate, setSelectedDate] = useState<Date | null>(null);

  useEffect(() => {
    if (value) {
      const date = new Date(value);
      setSelectedDate(date);
    }
  }, [value]);

  function _onChange(date: Date | null) {
    if (date) {
      setSelectedDate(date);
      try {
        const ISODateString = date.toISOString();
        setValue(ISODateString);
      } catch (error) {
        setValue(date);
      }
    } else {
      setValue(date);
    }
  }

  return (
    <FormControl error={meta.touched && !!meta.error} fullWidth variant={variant}>
      <LocalizationProvider dateAdapter={DateAdapter}>
        <DatePicker
          {...field}
          {...props}
          value={selectedDate}
          onChange={_onChange}
          renderInput={(params) =>
            <TextField
              fullWidth
              {...params}
            />
          }
        />
      </LocalizationProvider>
      {meta.touched && meta.error ? (
        <FormHelperText>{meta.error}</FormHelperText>
      ) : null}
    </FormControl >
  );
}


